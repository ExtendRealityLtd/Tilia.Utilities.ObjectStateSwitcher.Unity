# Changelog

## [1.1.0](https://github.com/ExtendRealityLtd/Tilia.Utilities.ObjectStateSwitcher.Unity/compare/v1.0.2...v1.1.0) (2019-12-05)

#### Features

* **UIButtonBuilder:** expose cached index operations ([8c045a3](https://github.com/ExtendRealityLtd/Tilia.Utilities.ObjectStateSwitcher.Unity/commit/8c045a3ee716e9fb9ed095c1e07fe15371aba7a9))
  > The CachedIndex can now be accessed via the `TryGetCachedIndex` method which will return the current cached index for the selected item if one has been set, otherwise the method will return false.
  > 
  > The `SwitchTo(int index)` method has also been exposed publicly so switching can happen programatically on the component and the relevant index cache is updated accordingly.
  > 
  > The `SwitchToCachedIndex` method also now has a `defaultWhenNoCachedIndex` optional parameter which can be used as the index to actually switch to if no cached index is present.
  > 
  > The prefab has been updated to use this new `SwitchToCachedIndex` method when the prefab is enabled.

### [1.0.2](https://github.com/ExtendRealityLtd/Tilia.Utilities.ObjectStateSwitcher.Unity/compare/v1.0.1...v1.0.2) (2019-12-02)

#### Miscellaneous Chores

* **deps:** bump io.extendreality.zinnia.unity from 1.8.1 to 1.9.0 ([71ef192](https://github.com/ExtendRealityLtd/Tilia.Utilities.ObjectStateSwitcher.Unity/commit/71ef1925b19fa8c666ab2c62d0d61bee820616bf))
  > Bumps [io.extendreality.zinnia.unity](https://github.com/ExtendRealityLtd/Zinnia.Unity) from 1.8.1 to 1.9.0. - [Release notes](https://github.com/ExtendRealityLtd/Zinnia.Unity/releases) - [Changelog](https://github.com/ExtendRealityLtd/Zinnia.Unity/blob/master/CHANGELOG.md) - [Commits](https://github.com/ExtendRealityLtd/Zinnia.Unity/compare/v1.8.1...v1.9.0)
  > 
  > Signed-off-by: dependabot-preview[bot] <support@dependabot.com>

### [1.0.1](https://github.com/ExtendRealityLtd/Tilia.Utilities.ObjectStateSwitcher.Unity/compare/v1.0.0...v1.0.1) (2019-11-27)

#### Miscellaneous Chores

* **deps:** bump io.extendreality.zinnia.unity from 1.8.0 to 1.8.1 ([b201d3d](https://github.com/ExtendRealityLtd/Tilia.Utilities.ObjectStateSwitcher.Unity/commit/b201d3d2ad16cf42344afe7235fc746daef686b6))
  > Bumps [io.extendreality.zinnia.unity](https://github.com/ExtendRealityLtd/Zinnia.Unity) from 1.8.0 to 1.8.1. - [Release notes](https://github.com/ExtendRealityLtd/Zinnia.Unity/releases) - [Changelog](https://github.com/ExtendRealityLtd/Zinnia.Unity/blob/master/CHANGELOG.md) - [Commits](https://github.com/ExtendRealityLtd/Zinnia.Unity/compare/v1.8.0...v1.8.1)
  > 
  > Signed-off-by: dependabot-preview[bot] <support@dependabot.com>

## 1.0.0 (2019-11-07)

#### Features

* **structure:** create initial prefab and user guides ([2c59a79](https://github.com/ExtendRealityLtd/Tilia.Utilities.ObjectStateSwitcher.Unity/commit/2c59a793aad9ea5b82a3b0db398bc6e4bddf5f96))
  > The structure of the repository has been created with all the required files for the package, the prefab and the documentation.

#### Bug Fixes

* **HowToGuides:** add missing meta files for images ([16c5df6](https://github.com/ExtendRealityLtd/Tilia.Utilities.ObjectStateSwitcher.Unity/commit/16c5df6de7cd73fb3cddeb629254125dd5c58557))
  > There were missing image .meta files as for some reason Unity seems to randomly take ages to generate .meta files for images on some occasions.
