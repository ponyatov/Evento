module CMake

let CMakeLists: unit = //
    File.WriteAllText(
        "CMakeLists.txt",
        """cmake_minimum_required(VERSION 3.22)
get_filename_component(CMAKE_PROJECT_NAME ${CMAKE_SOURCE_DIR} NAME_WE)
project(${CMAKE_PROJECT_NAME} LANGUAGES C CXX ASM)

include(version)        # binary files naming by version & git branch/hash
include(src)            # scan project for source code files
include(syntax)         # parser generators (flex,yacc/bison,ragel,lemon,..)

message("-- |")
message("-- | toolchain: " ${CMAKE_CXX_COMPILER} " @ " ${CMAKE_TOOLCHAIN_FILE})
message("-- |      host: " ${CMAKE_HOST_SYSTEM_NAME}-${CMAKE_HOST_SYSTEM_VERSION})
message("-- |    target: " "hw:" ${HW} " cpu:" ${CPU} " arch:" ${ARCH} " os:" ${OS})
message("-- |   startup: " "${S}")
message("-- |    linker: " "${LD}")
message("-- |    binary: " ${CMAKE_INSTALL_PREFIX}/${BIN_OUTPUT_NAME}${CMAKE_EXECUTABLE_SUFFIX})
message("-- |")

add_executable(${CMAKE_PROJECT_NAME}
    ${C}  ${H}          # C/C++ source
    ${S}  ${LD}         # embedded/lowlevel
    ${CP} ${HP} ${OP}   # parsers
)

# target_link_libraries(${CMAKE_PROJECT_NAME} -static)

include(install)        # target install
include(cross)          # cross compiler binaries: elf/dfu
include(clean)          # project clean-up (remove generated & temp files)
"""
    )

let CMakePresets: unit = //
    File.WriteAllText(
        "CMakePresets.json",
        """{
    "version": 6,
    "buildPresets": [
        {
            "name"            :  "linux",
            "configurePreset" :  "linux",
            "targets"         : ["all","install"]
        }
    ],
    "configurePresets": [
        {
            "name"            : "common",
            "hidden"          :  true,
            "binaryDir"       : "${sourceDir}/tmp/${presetName}",
            "generator"       : "Unix Makefiles",
            "cacheVariables"  : {
                "CMAKE_INSTALL_PREFIX"    : "${sourceDir}/bin",
                "CMAKE_MODULE_PATH"       : "${sourceDir}/cmake",
                "CMAKE_COLOR_DIAGNOSTICS" :  false,
                "CMAKE_BUILD_TYPE"        : "Debug",
                "CMAKE_VERBOSE_MAKEFILE"  :  false
            }
        },
        {
            "name"            : "pc",
            "inherits"        : "common",
            "hidden"          :  true,
            "cacheVariables"  : {"HW":"pc", "CPU":"i5", "ARCH":"x86_64"}
        },
        {
            "name"            : "linux",
            "inherits"        : "pc",
            "toolchainFile"   : "${sourceDir}/cmake/x86_64-linux-gnu.cmake",
            "cacheVariables"  : {"OS":"linux"}
        }
    ]
}
"""
    )

let cmake: unit = //
    mkdir "cmake"
    CMakeLists
    CMakePresets

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
