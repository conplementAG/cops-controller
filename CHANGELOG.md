# Changelog

## [1.8.0](https://github.com/conplementAG/cops-controller/compare/1.7.0...v1.8.0) (2025-10-06)


### Features

* quaterly updates ([a4252fc](https://github.com/conplementAG/cops-controller/commit/a4252fc694b56c0b5a4aa15fd9935d44adb965df))

## [1.7.0](https://github.com/conplementAG/cops-controller/compare/1.6.0...v1.7.0) (2025-07-15)


### Features

* quarterly updates ([bffd5b9](https://github.com/conplementAG/cops-controller/commit/bffd5b906bb0ea02c90458f6bf47da5012172f66))


### Bug Fixes

* **dtrack:** make sure sbom is in version 1.5 ([8f5ff58](https://github.com/conplementAG/cops-controller/commit/8f5ff584748d8500c93e1fa5fc3cab7bd1b7e737))

## [1.6.1](https://github.com/conplementAG/cops-controller/compare/1.6.0...v1.6.1) (2025-05-27)


### Bug Fixes

* **dtrack:** make sure sbom is in version 1.5 ([8f5ff58](https://github.com/conplementAG/cops-controller/commit/8f5ff584748d8500c93e1fa5fc3cab7bd1b7e737))

## [1.6.0](https://github.com/conplementAG/cops-controller/compare/1.5.0...v1.6.0) (2025-04-11)


### Features

* **housekeeping:** upgrade quaterly ([49e4a67](https://github.com/conplementAG/cops-controller/commit/49e4a6766d7e6e7270570dbcb8aba5c41b314044))

## [1.5.0](https://github.com/conplementAG/cops-controller/compare/1.4.0...v1.5.0) (2024-09-30)


### Features

* update quaterly ([1938afc](https://github.com/conplementAG/cops-controller/commit/1938afc7dcce6787403d8425b6939109c7b2b558))

## [1.4.0](https://github.com/conplementAG/cops-controller/compare/1.3.0...v1.4.0) (2024-04-15)


### Features

* **container:** use chiseled base image ([b46ab44](https://github.com/conplementAG/cops-controller/commit/b46ab44d63d5e006a7684b7b379cf347bdc21627))
* **pipeline:** remove trivy ([0c6d579](https://github.com/conplementAG/cops-controller/commit/0c6d579bba9a1a4deabfc0d566fdf940dfcaa4f3))
* **sboms:** create sboms and upload to dtrack ([3482d06](https://github.com/conplementAG/cops-controller/commit/3482d066adfc1408fee06515614b62cf0f18efa9))

## [1.3.0](https://github.com/conplementAG/cops-controller/compare/1.2.0...v1.3.0) (2023-10-27)


### Features

* add labels only when set ([2099c53](https://github.com/conplementAG/cops-controller/commit/2099c539070c3b972da4bb7fb8bed797b151b728))
* add project name and costcenter labels ([ecd3437](https://github.com/conplementAG/cops-controller/commit/ecd3437e9245a74af4ff1e96e020bc410966892e))
* **docu:** adapt documentation for using telepresence ([9e05301](https://github.com/conplementAG/cops-controller/commit/9e053017e363aefe3415ccd6bb102c4cb81a641f))
* **tests:** add test for new crd version ([0bcff25](https://github.com/conplementAG/cops-controller/commit/0bcff2535b9af5db97b00cdf2f85d308b9bd485c))


### Bug Fixes

* adapt label names ([de25717](https://github.com/conplementAG/cops-controller/commit/de25717d781c0287a0a7189c6d140629e09a521b))
* make costcenter camel case ([47ba880](https://github.com/conplementAG/cops-controller/commit/47ba880d594f3f438c8d1747b7f41e615c90bd96))

## [1.2.0](https://github.com/conplementAG/cops-controller/compare/1.1.1...v1.2.0) (2022-12-05)


### Features

* upgrade .net and all dependencies ([0b898d1](https://github.com/conplementAG/cops-controller/commit/0b898d1433cb9fbaf9fa94616daa5ced199f8031))

## [1.1.1](https://github.com/conplementAG/cops-controller/compare/1.1.0...v1.1.1) (2022-06-30)


### Bug Fixes

* enable subresource status ([6391d8a](https://github.com/conplementAG/cops-controller/commit/6391d8a16b08a9cdce39bfaaabe59737e15135ab))

## [1.1.0](https://github.com/conplementAG/cops-controller/compare/1.0.0...v1.1.0) (2022-06-28)


### Features

* add trivy repo scanning ([557df0a](https://github.com/conplementAG/cops-controller/commit/557df0a6baf8cf50e29f2d75c24745f6f9659548))
* create build with triviy scan ([eaa9c5a](https://github.com/conplementAG/cops-controller/commit/eaa9c5a55c69bda71d95aa1518562634112a0b05))
* enable code scanning ([ab37d00](https://github.com/conplementAG/cops-controller/commit/ab37d007b29f7f7f1c4199c703abfb6405bead75))
* enable nuget package.lock.json to enable scanning with trivy ([6295027](https://github.com/conplementAG/cops-controller/commit/6295027bbadec30befd08f724974c9396b3fee71))
* upload trivy scan results to github security tab ([8973220](https://github.com/conplementAG/cops-controller/commit/8973220e7cbf0cd7c344501ac140cf7048822604))


### Bug Fixes

* adapt trivy output for upload ([e29eb51](https://github.com/conplementAG/cops-controller/commit/e29eb514020725b6296c4c5b97c82c0a8bd71e96))
* typo ([0cefd97](https://github.com/conplementAG/cops-controller/commit/0cefd972637923dc5a459bb3abae78310e2ab0f5))
* upgrade crd to current schema ([d0ca571](https://github.com/conplementAG/cops-controller/commit/d0ca571d5d770e67fc449283b9dfc1912b2facb1))

## 1.0.0 (2022-06-08)


### Features

* add nightly build ([9c9cc6e](https://github.com/conplementAG/cops-controller/commit/9c9cc6e4a552bb34f38678119a82d83e573aaa6c))
* add release action ([50920cc](https://github.com/conplementAG/cops-controller/commit/50920cc7cfdb79500fc164bddd44d652042c995d))
* add trivy in ci pipeline ([b320a4e](https://github.com/conplementAG/cops-controller/commit/b320a4e9d330342aebed873d16037a49755d9156))
* added default admin role and rolebinding for namespace ([296148d](https://github.com/conplementAG/cops-controller/commit/296148dcc7b2f60866796d70e098b5230ab3e2ea))
* asp.net core application with namespace sync implementation ([e5cbdfe](https://github.com/conplementAG/cops-controller/commit/e5cbdfe7a275d3e05b60c3f27bafb8efcb47d701))
* binding to in-built edit role instead of maintaining our own ([f8ee711](https://github.com/conplementAG/cops-controller/commit/f8ee711bc1e26a56cf5b148d6981686ef148ead0))
* cops namespace crd, custom controller spec for metacontroller and usage example ([bea5198](https://github.com/conplementAG/cops-controller/commit/bea5198de9b866bb44d6fa0fb8db1479e1f2a355))
* Docker, Azure DevSpaces and Visual Studio Code support ([dfa2a8c](https://github.com/conplementAG/cops-controller/commit/dfa2a8cbbfbb19d707c69f9fe66f3a3781e32c34))
* does not push with tag latest anymore because latest would be an instable dev-version ([dc61c38](https://github.com/conplementAG/cops-controller/commit/dc61c387899f586a9a59cf23e26007ee5c33af78))
* handles --namespace-parametre correctly for installation via helm ([527fb6b](https://github.com/conplementAG/cops-controller/commit/527fb6bf793bee8e4ecbfb6fee5950776f3f5efe))
* initial helm deployment ([793c710](https://github.com/conplementAG/cops-controller/commit/793c710582b60bdc5f6b322e2fed6019635739f9))
* introduce limit range in CompositeController ([504fc07](https://github.com/conplementAG/cops-controller/commit/504fc0734ef23eb91a11d4302cacaeb8ea444666))
* namespace-admin-users field and validation, updated docs for note on installing CRDs ([86334af](https://github.com/conplementAG/cops-controller/commit/86334af238bdfd09f7628be506db4f575e5f2aa9))
* non-root docker image ([99f5058](https://github.com/conplementAG/cops-controller/commit/99f5058df67c063e3b517ffa419bb6ec13e8f55b))
* publishes helm chart as artefact for release pipeline ([515a70a](https://github.com/conplementAG/cops-controller/commit/515a70a0489331944e66cb1f779ac2abed700e51))
* push to ACR [skip ci] ([fff12b8](https://github.com/conplementAG/cops-controller/commit/fff12b8e02794fd28a0b76764b86450e5dc1b7c6))
* push to docker hub ([5fa1925](https://github.com/conplementAG/cops-controller/commit/5fa1925419939d43e897e10dfa6bad142fa35ed7))
* pushing latest image [skip ci] ([9a0a06e](https://github.com/conplementAG/cops-controller/commit/9a0a06edd9217828a74259bb7aa5e0ace6aa4a40))
* release via github action ([74e986a](https://github.com/conplementAG/cops-controller/commit/74e986ac354e3e89cfec49ba39ffbfba22e4622c))
* rename chart folder to cops-controller, because chart-name must match folder-name for helm package ([2be394e](https://github.com/conplementAG/cops-controller/commit/2be394e35725c12d5df14792694f45a5831bc336))
* resource namespacing, complete deployment through helm chart ([9725060](https://github.com/conplementAG/cops-controller/commit/972506095bcd496244bef591f8e0d42af2793e7d))
* service account support, rename of roles and bindings for clarity ([d2127f5](https://github.com/conplementAG/cops-controller/commit/d2127f54af577120770161b028bac21bb3dba9e4))
* strong validation of service account schema using crd validation ([0f5cc8f](https://github.com/conplementAG/cops-controller/commit/0f5cc8fb8a412cc6f2e91f547c0031621bb0a53c))
* switch to ubuntu base image ([49a711c](https://github.com/conplementAG/cops-controller/commit/49a711c03a68aecaef13ac4e279c1798398900bd))
* update hosted build pool ([727515c](https://github.com/conplementAG/cops-controller/commit/727515cd0eaee38e75e01652072283846f1921ad))
* upgrade .net 5.0 ([cdcf3ba](https://github.com/conplementAG/cops-controller/commit/cdcf3bae78e5c55b260ade15511c583b0c88de41))
* upgrade .net core 3.1 ([7a0dd41](https://github.com/conplementAG/cops-controller/commit/7a0dd41501d7b557a217d1d09e1193796352426b))
* upgrade obsolete api versions ([6ddd345](https://github.com/conplementAG/cops-controller/commit/6ddd345f51b81a0274fef7431492e85b4eb62085))


### Bug Fixes

* ACR password field [skip ci] ([3792aa1](https://github.com/conplementAG/cops-controller/commit/3792aa170addff9bbd4e4da8ff4eacdc69a44ae4))
* add missing clusterrole child resource and fix clusterrole definition ([a81e706](https://github.com/conplementAG/cops-controller/commit/a81e7068e44c6c36f27c209e23c6c08b022f2c38))
* aligns the build artifact name with the folder name to statisfy helm ([6872866](https://github.com/conplementAG/cops-controller/commit/6872866c20d810c8c43e0b1cc6089bc4513ad22c))
* allow users to install helm in cops namespaces ([eb36039](https://github.com/conplementAG/cops-controller/commit/eb36039f60fb7a8129e015b74db3666f6c5ee0f6))
* bug when creating namespace without service accounts ([5e56b20](https://github.com/conplementAG/cops-controller/commit/5e56b206b363f391d3a725df0bf62a8b839b13bf))
* changes docker tag naming, to statisfy helm versioning ([a3056b6](https://github.com/conplementAG/cops-controller/commit/a3056b6adb117245f76086287af98896552a04b0))
* controller name ([e1e115a](https://github.com/conplementAG/cops-controller/commit/e1e115ad344d6bf2277317b23ec22f7da518c226))
* correct child resource name for limit ranges ([2a94195](https://github.com/conplementAG/cops-controller/commit/2a941956bec70a9a3db62c03da4d631c608a44f5))
* correct docker id ([d84c1e1](https://github.com/conplementAG/cops-controller/commit/d84c1e11de35901ed7571c8dcd28951c5565812a))
* crd fix for helm race condition (crds need 2-3 seconds) ([4a0f429](https://github.com/conplementAG/cops-controller/commit/4a0f429f6d1f15dbdeae3796e5315bee67ff52e0))
* docker username ([efabaa3](https://github.com/conplementAG/cops-controller/commit/efabaa39de63b183d009ea5266b422a7fd492476))
* fixes k8s-apiversion and imagePullPolicy ([dadadff](https://github.com/conplementAG/cops-controller/commit/dadadffcc27a73e97e48083585571999b967cb2f))
* helm chart fix for image repository ([4342318](https://github.com/conplementAG/cops-controller/commit/43423183782b433579ee73896dce3c7183d7453c))
* metacontroller going into infinite "hot" loop ([33e98ed](https://github.com/conplementAG/cops-controller/commit/33e98edc78339c95ab2ff06f70cedbb9163fae62))
* patch and delete functionality for users creating the cops namespaces ([674fbe5](https://github.com/conplementAG/cops-controller/commit/674fbe512e07cb4d1c3c9dcd2b07639014237697))
* patch and delete functionality for users creating the cops namespaces ([a819b6f](https://github.com/conplementAG/cops-controller/commit/a819b6f499184242b06f2c43db8b1fab92fc4685))
* remove Azure devops badge ([abee15c](https://github.com/conplementAG/cops-controller/commit/abee15c8410fd990a8dbed7abc650c52cbaabf82))
* remove csproj user file ([c63fbdb](https://github.com/conplementAG/cops-controller/commit/c63fbdb27a4a74a13ab5639220f4a378155df7f4))
* remove elasticsearch log format ([e3900a4](https://github.com/conplementAG/cops-controller/commit/e3900a4b3b23074e3ce8bb3fbceb9a96fbe5fec4))
* remove obsolete service account ([c7155d2](https://github.com/conplementAG/cops-controller/commit/c7155d295258f7995b10c2ab81f3004ccd7d67fb))
* serilog log level env variable name ([17a249e](https://github.com/conplementAG/cops-controller/commit/17a249e7a5978809917c5392434937f3cd3c88d9))
* sets correct folder name for azure-dev-spaces ([810b015](https://github.com/conplementAG/cops-controller/commit/810b0155c55b2bdc88aef8556a6631f401802bf2))
* switch to cluster-admin instead of edit cluster role to include CRDs. Additional tests ([cf32cbc](https://github.com/conplementAG/cops-controller/commit/cf32cbc48ccc83532e939345146f9996d6ace2fe))
* sync debug line ([a0df70c](https://github.com/conplementAG/cops-controller/commit/a0df70c0bf35cbcd88016eb5dc1aac3be3ab6f62))
* updates publish path according to changed directory name ([e5e7c2a](https://github.com/conplementAG/cops-controller/commit/e5e7c2a0677d076c25a8cccad81d12e21786446a))
