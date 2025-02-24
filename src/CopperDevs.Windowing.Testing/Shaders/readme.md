### Cross-Compiling Shaders

Shaders are generated using [SDL's shadercross](https://github.com/libsdl-org/SDL_shadercross) tool to generate SPIR-V/DXIL/MSL shaders. You can view the `compile.sh` script to see how it is used to generate the shader in this repo. You can download prebuilt archives of SDL_shadercross from [its Github Actions](https://github.com/libsdl-org/SDL_shadercross/actions).

SDL GPU Shaders require specific resource bindings. You can [read about that here](https://wiki.libsdl.org/SDL3/SDL_CreateGPUShader#remarks).