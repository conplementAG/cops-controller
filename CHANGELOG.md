# Changelog

## [0.6.1](https://github.com/conplementAG/cops-controller/compare/v0.6.0...v0.6.1) (2022-06-07)


### Bug Fixes

* dynamic chart version ([eccecdb](https://github.com/conplementAG/cops-controller/commit/eccecdb60fa73a609295613e4e3fbba83dfa2ff0))

## [0.6.0](https://github.com/conplementAG/cops-controller/compare/v0.5.2...v0.6.0) (2022-06-07)


### Features

* add helm chart releaser ([acd4cbd](https://github.com/conplementAG/cops-controller/commit/acd4cbdc6838c4611154bdcce731c87d46809e42))

## [0.5.2](https://github.com/conplementAG/cops-controller/compare/v0.5.1...v0.5.2) (2022-06-07)


### Bug Fixes

* allow update and replace ([9235601](https://github.com/conplementAG/cops-controller/commit/92356013cd0653b24b4f409e2f7c08584b382af0))

## [0.5.1](https://github.com/conplementAG/cops-controller/compare/v0.5.0...v0.5.1) (2022-06-07)


### Bug Fixes

* adapt helm release ([39c5244](https://github.com/conplementAG/cops-controller/commit/39c5244565657d2e187ffd0c672d02ee4140f61c))

## [0.5.0](https://github.com/conplementAG/cops-controller/compare/v0.4.1...v0.5.0) (2022-06-07)


### Features

* add helm release ([129431d](https://github.com/conplementAG/cops-controller/commit/129431d788a9b1273564080c9f88c0de57fb667b))

## [0.4.0](https://github.com/conplementAG/cops-controller/compare/v0.3.0...v0.4.0) (2022-06-07)


### Features

* add basepath to release helm chart only ([21241ad](https://github.com/conplementAG/cops-controller/commit/21241ad006f37e62de23d08512df4704971de6a3))
* add condition for pipelinestep ([f951727](https://github.com/conplementAG/cops-controller/commit/f9517276896d2fe0a1dbd05a7e590f0efbd1a11d))
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
* rename chart folder to cops-controller, because chart-name must match folder-name for helm package ([2be394e](https://github.com/conplementAG/cops-controller/commit/2be394e35725c12d5df14792694f45a5831bc336))
* resource namespacing, complete deployment through helm chart ([9725060](https://github.com/conplementAG/cops-controller/commit/972506095bcd496244bef591f8e0d42af2793e7d))
* service account support, rename of roles and bindings for clarity ([d2127f5](https://github.com/conplementAG/cops-controller/commit/d2127f54af577120770161b028bac21bb3dba9e4))
* strong validation of service account schema using crd validation ([0f5cc8f](https://github.com/conplementAG/cops-controller/commit/0f5cc8fb8a412cc6f2e91f547c0031621bb0a53c))
* switch release please to command "manifest" ([09db52d](https://github.com/conplementAG/cops-controller/commit/09db52d9d43c0baafcca484e30a73c69a2653467))
* switch to ubuntu base image ([49a711c](https://github.com/conplementAG/cops-controller/commit/49a711c03a68aecaef13ac4e279c1798398900bd))
* update hosted build pool ([727515c](https://github.com/conplementAG/cops-controller/commit/727515cd0eaee38e75e01652072283846f1921ad))
* upgrade .net 5.0 ([cdcf3ba](https://github.com/conplementAG/cops-controller/commit/cdcf3bae78e5c55b260ade15511c583b0c88de41))
* upgrade .net core 3.1 ([7a0dd41](https://github.com/conplementAG/cops-controller/commit/7a0dd41501d7b557a217d1d09e1193796352426b))
* upgrade obsolete api versions ([6ddd345](https://github.com/conplementAG/cops-controller/commit/6ddd345f51b81a0274fef7431492e85b4eb62085))
* use release please version for chart ([f781fc1](https://github.com/conplementAG/cops-controller/commit/f781fc10bade95bac1e6c1596809d8a36dc005c9))


### Bug Fixes

* ACR password field [skip ci] ([3792aa1](https://github.com/conplementAG/cops-controller/commit/3792aa170addff9bbd4e4da8ff4eacdc69a44ae4))
* add crds to release config ([6f4a5ed](https://github.com/conplementAG/cops-controller/commit/6f4a5ed72ef031b8823448260f3f008a441ac8fa))
* add missing clusterrole child resource and fix clusterrole definition ([a81e706](https://github.com/conplementAG/cops-controller/commit/a81e7068e44c6c36f27c209e23c6c08b022f2c38))
* aligns the build artifact name with the folder name to statisfy helm ([6872866](https://github.com/conplementAG/cops-controller/commit/6872866c20d810c8c43e0b1cc6089bc4513ad22c))
* allow users to install helm in cops namespaces ([eb36039](https://github.com/conplementAG/cops-controller/commit/eb36039f60fb7a8129e015b74db3666f6c5ee0f6))
* Branche Name in pipeline ([8ac1370](https://github.com/conplementAG/cops-controller/commit/8ac1370502fe1daebded4c5f1e6130432b718723))
* bug when creating namespace without service accounts ([5e56b20](https://github.com/conplementAG/cops-controller/commit/5e56b206b363f391d3a725df0bf62a8b839b13bf))
* change releasetype to simple ([a844568](https://github.com/conplementAG/cops-controller/commit/a844568c42b9fd570383e3012173680308eb51eb))
* change targetbranch ([4b1f6ac](https://github.com/conplementAG/cops-controller/commit/4b1f6acb12332f79cbd58e5a351643b9e6664588))
* changes docker tag naming, to statisfy helm versioning ([a3056b6](https://github.com/conplementAG/cops-controller/commit/a3056b6adb117245f76086287af98896552a04b0))
* cleanup azure pipelines and changelogs ([3f7886b](https://github.com/conplementAG/cops-controller/commit/3f7886bdc33b4e7949246078e02de8d7511e9464))
* controller name ([e1e115a](https://github.com/conplementAG/cops-controller/commit/e1e115ad344d6bf2277317b23ec22f7da518c226))
* correct child resource name for limit ranges ([2a94195](https://github.com/conplementAG/cops-controller/commit/2a941956bec70a9a3db62c03da4d631c608a44f5))
* correct docker id ([d84c1e1](https://github.com/conplementAG/cops-controller/commit/d84c1e11de35901ed7571c8dcd28951c5565812a))
* correct path for additional files in release please step ([50efdb2](https://github.com/conplementAG/cops-controller/commit/50efdb266673ead5263829e332f736e762fbef25))
* crd fix for helm race condition (crds need 2-3 seconds) ([4a0f429](https://github.com/conplementAG/cops-controller/commit/4a0f429f6d1f15dbdeae3796e5315bee67ff52e0))
* docker username ([efabaa3](https://github.com/conplementAG/cops-controller/commit/efabaa39de63b183d009ea5266b422a7fd492476))
* extra files in release please step ([e1bec41](https://github.com/conplementAG/cops-controller/commit/e1bec413f246f2a2a6cff92ce8b53a7222e1b831))
* fixes k8s-apiversion and imagePullPolicy ([dadadff](https://github.com/conplementAG/cops-controller/commit/dadadffcc27a73e97e48083585571999b967cb2f))
* helm chart fix for image repository ([4342318](https://github.com/conplementAG/cops-controller/commit/43423183782b433579ee73896dce3c7183d7453c))
* login for docker hub ([9e3fb21](https://github.com/conplementAG/cops-controller/commit/9e3fb2120d0b0f63296af3aca3e6b52830fc6266))
* metacontroller going into infinite "hot" loop ([33e98ed](https://github.com/conplementAG/cops-controller/commit/33e98edc78339c95ab2ff06f70cedbb9163fae62))
* patch and delete functionality for users creating the cops namespaces ([674fbe5](https://github.com/conplementAG/cops-controller/commit/674fbe512e07cb4d1c3c9dcd2b07639014237697))
* patch and delete functionality for users creating the cops namespaces ([a819b6f](https://github.com/conplementAG/cops-controller/commit/a819b6f499184242b06f2c43db8b1fab92fc4685))
* readd release-please-manifest.json ([c7209b4](https://github.com/conplementAG/cops-controller/commit/c7209b47ccd0dddf1ec2d90687da73b008e82e73))
* release only deplyoment ([07cf3d3](https://github.com/conplementAG/cops-controller/commit/07cf3d31fbebaf7add998e1258267a0fcfbaf2dd))
* release please path ([99587dc](https://github.com/conplementAG/cops-controller/commit/99587dce81571519cfd75b535eb2a101bad5fc23))
* release without manifest ([a9e887f](https://github.com/conplementAG/cops-controller/commit/a9e887fb65de47dc5d12ed69d5baf20b089b709f))
* remove Azure devops badge ([abee15c](https://github.com/conplementAG/cops-controller/commit/abee15c8410fd990a8dbed7abc650c52cbaabf82))
* remove csproj user file ([c63fbdb](https://github.com/conplementAG/cops-controller/commit/c63fbdb27a4a74a13ab5639220f4a378155df7f4))
* remove elasticsearch log format ([e3900a4](https://github.com/conplementAG/cops-controller/commit/e3900a4b3b23074e3ce8bb3fbceb9a96fbe5fec4))
* remove obsolete service account ([c7155d2](https://github.com/conplementAG/cops-controller/commit/c7155d295258f7995b10c2ab81f3004ccd7d67fb))
* serilog log level env variable name ([17a249e](https://github.com/conplementAG/cops-controller/commit/17a249e7a5978809917c5392434937f3cd3c88d9))
* set helm chart api version ([dc142ee](https://github.com/conplementAG/cops-controller/commit/dc142ee1dfc05e111565397dda0f38bd653f69f2))
* sets correct folder name for azure-dev-spaces ([810b015](https://github.com/conplementAG/cops-controller/commit/810b0155c55b2bdc88aef8556a6631f401802bf2))
* switch to cluster-admin instead of edit cluster role to include CRDs. Additional tests ([cf32cbc](https://github.com/conplementAG/cops-controller/commit/cf32cbc48ccc83532e939345146f9996d6ace2fe))
* sync debug line ([a0df70c](https://github.com/conplementAG/cops-controller/commit/a0df70c0bf35cbcd88016eb5dc1aac3be3ab6f62))
* updates publish path according to changed directory name ([e5e7c2a](https://github.com/conplementAG/cops-controller/commit/e5e7c2a0677d076c25a8cccad81d12e21786446a))
* use manifest-pr ([01bca9c](https://github.com/conplementAG/cops-controller/commit/01bca9cdc0cc5438b98890b3e8cef8f522aa8607))
