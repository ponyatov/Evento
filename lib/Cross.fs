let hw: unit = //
    mkdir "hw"
    mkdir "hw/inc"
    mkdir "hw/src"

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
