module CMake

let cmake: unit = //
    mkdir "cmake"

    for cm in
        [ "any_toolchain"
          "x86_64-linux-gnu"
          "aarch64-linux-gnu"
          "arm-none-eabi"
          "xtensa-lx106-elf"
          "i686-w64-mingw32"
          "syntax"
          "FindLEMON"
          "FindReadline"
          "FindRAGEL"
          "clean"
          "src"
          "version"
          "cross"
          "install" ] do
        File.WriteAllText($"cmake/{cm}.cmake", "")
