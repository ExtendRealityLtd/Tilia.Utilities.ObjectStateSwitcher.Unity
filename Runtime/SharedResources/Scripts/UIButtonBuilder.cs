namespace Tilia.Utilities.ObjectStateSwitcher
{
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    using Zinnia.Extension;
    using Zinnia.Tracking.Modification;

    /// <summary>
    /// Manages the drawing of the UI Buttons for the <see cref="Switcher"/> and assigning their actions.
    /// </summary>
    public class UIButtonBuilder : MonoBehaviour
    {
        [Tooltip("The GameObject container of the buttons.")]
        [SerializeField]
        private GameObject container;
        /// <summary>
        /// The <see cref="GameObject"/> container of the buttons.
        /// </summary>
        public GameObject Container
        {
            get
            {
                return container;
            }
            set
            {
                container = value;
            }
        }
        [Tooltip("The RectTransform associated with the container panel.")]
        [SerializeField]
        private RectTransform containerRect;
        /// <summary>
        /// The <see cref="RectTransform"/> associated with the container panel.
        /// </summary>
        public RectTransform ContainerRect
        {
            get
            {
                return containerRect;
            }
            set
            {
                containerRect = value;
            }
        }
        [Tooltip("The GameObject that holds the source Button for the UI.")]
        [SerializeField]
        private GameObject sourceButton;
        /// <summary>
        /// The <see cref="GameObject"/> that holds the source <see cref="Button"/> for the UI.
        /// </summary>
        public GameObject SourceButton
        {
            get
            {
                return sourceButton;
            }
            set
            {
                sourceButton = value;
            }
        }
        [Tooltip("The default padding for the final panel height.")]
        [SerializeField]
        private float panelHeightPadding = 10f;
        /// <summary>
        /// The default padding for the final panel height.
        /// </summary>
        public float PanelHeightPadding
        {
            get
            {
                return panelHeightPadding;
            }
            set
            {
                panelHeightPadding = value;
            }
        }
        [Tooltip("The default height padding between each button.")]
        [SerializeField]
        private float buttonHeightPadding = 5f;
        /// <summary>
        /// The default height padding between each button.
        /// </summary>
        public float ButtonHeightPadding
        {
            get
            {
                return buttonHeightPadding;
            }
            set
            {
                buttonHeightPadding = value;
            }
        }
        [Tooltip("The state switcher.")]
        [SerializeField]
        private GameObjectStateSwitcher switcher;
        /// <summary>
        /// The state switcher.
        /// </summary>
        public GameObjectStateSwitcher Switcher
        {
            get
            {
                return switcher;
            }
            set
            {
                switcher = value;
            }
        }

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
        /// Clears <see cref="Container"/>.
        /// </summary>
        public virtual void ClearContainer()
        {
            if (!this.IsValidState())
            {
                return;
            }

            Container = default;
        }

        /// <summary>
        /// Clears <see cref="SourceButton"/>.
        /// </summary>
        public virtual void ClearSourceButton()
        {
            if (!this.IsValidState())
            {
                return;
            }

            SourceButton = default;
        }

        /// <summary>
        /// Clears <see cref="Switcher"/>.
        /// </summary>
        public virtual void ClearSwitcher()
        {
            if (!this.IsValidState())
            {
                return;
            }

            Switcher = default;
        }

        /// <summary>
        /// Switches the <see cref="Switcher"/> to the given index.
        /// </summary>
        /// <param name="index">The index to switch to.</param>
        public virtual void SwitchTo(int index)
        {
            if (!this.IsValidState())
            {
                return;
            }

            Switcher.SwitchTo(index);
            cachedIndexCollection[Switcher.name] = index;
        }

        /// <summary>
        /// Attempts to receive the cached index for the current switcher.
        /// </summary>
        /// <param name="cachedIndex">The reference to the found cached index.</param>
        /// <returns>Whether a cached index was found.</returns>
        public virtual bool TryGetCachedIndex(out int cachedIndex)
        {
            return cachedIndexCollection.TryGetValue(Switcher.name, out cachedIndex);
        }

        /// <summary>
        /// Switches the <see cref="Switcher"/> to the current cached index.
        /// </summary>
        /// <param name="defaultWhenNoCachedIndex">The index to switch to if no cached index is present.</param>
        public virtual void SwitchToCachedIndex(int defaultWhenNoCachedIndex = 0)
        {
            if (!this.IsValidState())
            {
                return;
            }

            SwitchTo(TryGetCachedIndex(out int cachedIndex) ? cachedIndex : defaultWhenNoCachedIndex);
        }

        /// <summary>
        /// Creates a new UI Button that will enable the given Source.
        /// </summary>
        /// <param name="source">The <see cref="GameObject"/> to enable.</param>
        public virtual void CreateButton(GameObject source)
        {
            if (!this.IsValidState() || !IsValid() || sourceButtons.ContainsKey(source))
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