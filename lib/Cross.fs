let pc: unit = //
    mkdir "hw/pc"
    mkdir "hw/pc/inc"
    mkdir "hw/pc/src"
    touch "hw/pc/inc/pc.hpp"
    touch "hw/pc/src/pc.cpp"

let f429disco: unit = //
    mkdir "hw/f429disco"
    mkdir "hw/f429disco/inc"
    mkdir "hw/f429disco/src"
    touch "hw/f429disco/inc/f429disco.hpp"
    touch "hw/f429disco/src/f429disco.cpp"

let pillf103: unit = //
    mkdir "hw/pillf103"
    mkdir "hw/pillf103/inc"
    mkdir "hw/pillf103/src"
    touch "hw/pillf103/inc/pillf103.hpp"
    touch "hw/pillf103/src/pillf103.cpp"

let hw: unit = //
    mkdir "hw"
    mkdir "hw/inc"
    mkdir "hw/src"
    pc
    f429disco
    pillf103

let cpu: unit = //
    mkdir "cpu"
    mkdir "cpu/inc"
    mkdir "cpu/src"

let arch: unit = //
    mkdir "arch"
    mkdir "arch/inc"
    mkdir "arch/src"

let os: unit = //
    mkdir "os"
    mkdir "os/inc"
    mkdir "os/src"

let cross: unit = //
    hw
    cpu
    arch
    os
