# Changelog

## [0.2.0](https://github.com/conplementAG/cops-controller/compare/0.1.0...v0.2.0) (2022-06-07)


### Features

* add condition for pipelinestep ([f951727](https://github.com/conplementAG/cops-controller/commit/f9517276896d2fe0a1dbd05a7e590f0efbd1a11d))
* add nightly build ([9c9cc6e](https://github.com/conplementAG/cops-controller/commit/9c9cc6e4a552bb34f38678119a82d83e573aaa6c))
* add release action ([50920cc](https://github.com/conplementAG/cops-controller/commit/50920cc7cfdb79500fc164bddd44d652042c995d))
* add trivy in ci pipeline ([b320a4e](https://github.com/conplementAG/cops-controller/commit/b320a4e9d330342aebed873d16037a49755d9156))
* binding to in-built edit role instead of maintaining our own ([f8ee711](https://github.com/conplementAG/cops-controller/commit/f8ee711bc1e26a56cf5b148d6981686ef148ead0))
* does not push with tag latest anymore because latest would be an instable dev-version ([dc61c38](https://github.com/conplementAG/cops-controller/commit/dc61c387899f586a9a59cf23e26007ee5c33af78))
* handles --namespace-parametre correctly for installation via helm ([527fb6b](https://github.com/conplementAG/cops-controller/commit/527fb6bf793bee8e4ecbfb6fee5950776f3f5efe))
* introduce limit range in CompositeController ([504fc07](https://github.com/conplementAG/cops-controller/commit/504fc0734ef23eb91a11d4302cacaeb8ea444666))
* publishes helm chart as artefact for release pipeline ([515a70a](https://github.com/conplementAG/cops-controller/commit/515a70a0489331944e66cb1f779ac2abed700e51))
* rename chart folder to cops-controller, because chart-name must match folder-name for helm package ([2be394e](https://github.com/conplementAG/cops-controller/commit/2be394e35725c12d5df14792694f45a5831bc336))
* service account support, rename of roles and bindings for clarity ([d2127f5](https://github.com/conplementAG/cops-controller/commit/d2127f54af577120770161b028bac21bb3dba9e4))
* strong validation of service account schema using crd validation ([0f5cc8f](https://github.com/conplementAG/cops-controller/commit/0f5cc8fb8a412cc6f2e91f547c0031621bb0a53c))
* switch to ubuntu base image ([49a711c](https://github.com/conplementAG/cops-controller/commit/49a711c03a68aecaef13ac4e279c1798398900bd))
* update hosted build pool ([727515c](https://github.com/conplementAG/cops-controller/commit/727515cd0eaee38e75e01652072283846f1921ad))
* upgrade .net 5.0 ([cdcf3ba](https://github.com/conplementAG/cops-controller/commit/cdcf3bae78e5c55b260ade15511c583b0c88de41))
* upgrade .net core 3.1 ([7a0dd41](https://github.com/conplementAG/cops-controller/commit/7a0dd41501d7b557a217d1d09e1193796352426b))
* upgrade obsolete api versions ([6ddd345](https://github.com/conplementAG/cops-controller/commit/6ddd345f51b81a0274fef7431492e85b4eb62085))


### Bug Fixes

* add missing clusterrole child resource and fix clusterrole definition ([a81e706](https://github.com/conplementAG/cops-controller/commit/a81e7068e44c6c36f27c209e23c6c08b022f2c38))
* aligns the build artifact name with the folder name to statisfy helm ([6872866](https://github.com/conplementAG/cops-controller/commit/6872866c20d810c8c43e0b1cc6089bc4513ad22c))
* allow users to install helm in cops namespaces ([eb36039](https://github.com/conplementAG/cops-controller/commit/eb36039f60fb7a8129e015b74db3666f6c5ee0f6))
* Branche Name in pipeline ([8ac1370](https://github.com/conplementAG/cops-controller/commit/8ac1370502fe1daebded4c5f1e6130432b718723))
* bug when creating namespace without service accounts ([5e56b20](https://github.com/conplementAG/cops-controller/commit/5e56b206b363f391d3a725df0bf62a8b839b13bf))
* changes docker tag naming, to statisfy helm versioning ([a3056b6](https://github.com/conplementAG/cops-controller/commit/a3056b6adb117245f76086287af98896552a04b0))
* correct child resource name for limit ranges ([2a94195](https://github.com/conplementAG/cops-controller/commit/2a941956bec70a9a3db62c03da4d631c608a44f5))
* fixes k8s-apiversion and imagePullPolicy ([dadadff](https://github.com/conplementAG/cops-controller/commit/dadadffcc27a73e97e48083585571999b967cb2f))
* helm chart fix for image repository ([4342318](https://github.com/conplementAG/cops-controller/commit/43423183782b433579ee73896dce3c7183d7453c))
* login for docker hub ([9e3fb21](https://github.com/conplementAG/cops-controller/commit/9e3fb2120d0b0f63296af3aca3e6b52830fc6266))
* metacontroller going into infinite "hot" loop ([33e98ed](https://github.com/conplementAG/cops-controller/commit/33e98edc78339c95ab2ff06f70cedbb9163fae62))
* patch and delete functionality for users creating the cops namespaces ([674fbe5](https://github.com/conplementAG/cops-controller/commit/674fbe512e07cb4d1c3c9dcd2b07639014237697))
* patch and delete functionality for users creating the cops namespaces ([a819b6f](https://github.com/conplementAG/cops-controller/commit/a819b6f499184242b06f2c43db8b1fab92fc4685))
* remove Azure devops badge ([abee15c](https://github.com/conplementAG/cops-controller/commit/abee15c8410fd990a8dbed7abc650c52cbaabf82))
* remove elasticsearch log format ([e3900a4](https://github.com/conplementAG/cops-controller/commit/e3900a4b3b23074e3ce8bb3fbceb9a96fbe5fec4))
* remove obsolete service account ([c7155d2](https://github.com/conplementAG/cops-controller/commit/c7155d295258f7995b10c2ab81f3004ccd7d67fb))
* serilog log level env variable name ([17a249e](https://github.com/conplementAG/cops-controller/commit/17a249e7a5978809917c5392434937f3cd3c88d9))
* sets correct folder name for azure-dev-spaces ([810b015](https://github.com/conplementAG/cops-controller/commit/810b0155c55b2bdc88aef8556a6631f401802bf2))
* switch to cluster-admin instead of edit cluster role to include CRDs. Additional tests ([cf32cbc](https://github.com/conplementAG/cops-controller/commit/cf32cbc48ccc83532e939345146f9996d6ace2fe))
* sync debug line ([a0df70c](https://github.com/conplementAG/cops-controller/commit/a0df70c0bf35cbcd88016eb5dc1aac3be3ab6f62))
* updates publish path according to changed directory name ([e5e7c2a](https://github.com/conplementAG/cops-controller/commit/e5e7c2a0677d076c25a8cccad81d12e21786446a))
