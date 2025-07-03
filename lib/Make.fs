let makefile: unit = File.WriteAllText("Makefile")

let mk: unit =
    Directory.CreateDirectory("mk") |> ignore
    File.WriteAllText("mk/.gitignore", "!.gitignore\n")

    let makes =
        [ "var"
          "version"
          "dir"
          "tool"
          "src"
          "cfg"
          "all"
          "format"
          "rule"
          "doc"
          "install"
          "merge" ]

    for mk in makes do
        File.WriteAllText($"mk/{mk}.mk", "")

    File.WriteAllText(
        $"Makefile",
        (makes
         |> List.map (fun mk -> $"include mk/{mk}.mk")
         |> List.reduce (fun a b -> $"{a}\n{b}"))
        + "\n"
    )
