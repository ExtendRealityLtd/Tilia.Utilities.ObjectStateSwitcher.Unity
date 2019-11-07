namespace Tilia.Utilities.ObjectStateSwitcher
{
    using Malimbe.BehaviourStateRequirementMethod;
    using Malimbe.MemberClearanceMethod;
    using Malimbe.PropertySerializationAttribute;
    using Malimbe.XmlDocumentationAttribute;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    using Zinnia.Tracking.Modification;

    /// <summary>
    /// Manages the drawing of the UI Buttons for the <see cref="Switcher"/> and assigning their actions.
    /// </summary>
    public class UIButtonBuilder : MonoBehaviour
    {
        /// <summary>
        /// The <see cref="GameObject"/> container of the buttons.
        /// </summary>
        [Serialized, Cleared]
        [field: DocumentedByXml]
        public GameObject Container { get; set; }
        /// <summary>
        /// The <see cref="RectTransform"/> associated with the container panel.
        /// </summary>
        [Serialized]
        [field: DocumentedByXml]
        public RectTransform ContainerRect { get; set; }
        /// <summary>
        /// The <see cref="GameObject"/> that holds the source <see cref="Button"/> for the UI.
        /// </summary>
        [Serialized]
        [field: DocumentedByXml, Cleared]
        public GameObject SourceButton { get; set; }
        /// <summary>
        /// The default padding for the final panel height.
        /// </summary>
        [Serialized]
        [field: DocumentedByXml]
        public float PanelHeightPadding { get; set; } = 10f;
        /// <summary>
        /// The default height padding between each button.
        /// </summary>
        [Serialized]
        [field: DocumentedByXml]
        public float ButtonHeightPadding { get; set; } = 5f;
        /// <summary>
        /// The state switcher.
        /// </summary>
        [Serialized]
        [field: DocumentedByXml, Cleared]
        public GameObjectStateSwitcher Switcher { get; set; }

        /// <summary>
        /// The prefix to use when creating new button <see cref="GameObject"/>s.
        /// </summary>
        protected const string labelPrefix = "Button.";
        /// <summary>
        /// A collection of generated buttons linked to the source <see cref="GameObject"/> they are created for.
        /// </summary>
        protected Dictionary<GameObject, GameObject> sourceButtons = new Dictionary<GameObject, GameObject>();
        /// <summary>
        /// The inital size of the panel.
        /// </summary>
        protected Vector2 panelSize;
        /// <summary>
        /// The current cached index that will persist across scene changes.
        /// </summary>
        protected static Dictionary<string, int> cachedIndexCollection = new Dictionary<string, int>();

        /// <summary>
        /// Switches the <see cref="Switcher"/> to the current cached index.
        /// </summary>
        [RequiresBehaviourState]
        public virtual void SwitchToCachedIndex()
        {
            cachedIndexCollection.TryGetValue(Switcher.name, out int cachedIndex);
            SwitchTo(cachedIndex);
        }

        /// <summary>
        /// Creates a new UI Button that will enable the given Source.
        /// </summary>
        /// <param name="source">The <see cref="GameObject"/> to enable.</param>
        [RequiresBehaviourState]
        public virtual void CreateButton(GameObject source)
        {
            if (!IsValid() || sourceButtons.ContainsKey(source))
            {
                return;
            }

            GameObject newButton = Instantiate(SourceButton, Container.transform);
            newButton.gameObject.name = labelPrefix + source.name;
            newButton.GetComponentInChildren<Text>().text = source.name;
            newButton.SetActive(true);

            Button button = newButton.GetComponent<Button>();
            int index = sourceButtons.Count;
            button.onClick.AddListener(() => { SwitchTo(index); });

            sourceButtons.Add(source, newButton);

            RedrawButtons();
        }

        /// <summary>
        /// Deletes an existing UI Button.
        /// </summary>
        /// <param name="source">The <see cref="GameObject"/> being removed.</param>
        public virtual void DeleteButton(GameObject source)
        {
            if (!IsValid() || !sourceButtons.TryGetValue(source, out GameObject toDelete) || Switcher.Targets.Contains(source))
            {
                return;
            }

            sourceButtons.Remove(source);
            Destroy(toDelete);

            RedrawButtons();
        }

        protected virtual void Awake()
        {
            panelSize = ContainerRect.sizeDelta;
        }

        /// <summary>
        /// Switches the <see cref="Switcher"/> to the given index.
        /// </summary>
        /// <param name="index">The index to switch to.</param>
        protected virtual void SwitchTo(int index)
        {
            Switcher.SwitchTo(index);
            cachedIndexCollection[Switcher.name] = index;
        }

        /// <summary>
        /// Redraws the UI buttons.
        /// </summary>
        protected virtual void RedrawButtons()
        {
            RectTransform sourceTransform = SourceButton.GetComponent<RectTransform>();

            ContainerRect.sizeDelta = panelSize;

            float newHeight = sourceTransform.sizeDelta.y + ButtonHeightPadding;
            int currentButton = 0;
            foreach (KeyValuePair<GameObject, GameObject> button in sourceButtons)
            {
                RectTransform currentTransform = button.Value.GetComponent<RectTransform>();
                currentTransform.localPosition = sourceTransform.localPosition + (newHeight * currentButton * Vector3.down);
                currentButton++;
            }

            ContainerRect.sizeDelta += Vector2.up * (newHeight * sourceButtons.Count + (sourceButtons.Count == 0 ? 0f : PanelHeightPadding));
        }

        /// <summary>
        /// Determines if the relevant parameters are present.
        /// </summary>
        /// <returns>Whether the relevant parameters are present.</returns>
        protected virtual bool IsValid()
        {
            return Container != null && ContainerRect != null && SourceButton != null;
        }
    }
}