module Cpp

let HFILE (name: string) : string =
    let upper = name.ToUpper()
    $"_{upper}_H_"

let hpp: unit = //
    let H = HFILE APP
    File.WriteAllText(
        $"inc/{APP}.hpp",
        $"""#ifndef {H}
#define {H}

#include <stdio.h>
#include <stdlib.h>
#include <assert.h>

extern int  yylex();
extern int  yyparse();
extern void yyerror(char *msg);

#endif  // _EVENTO_H_
"""
    )

let cpp: unit =
    File.WriteAllText($"src/{APP}.cpp", $"""#include "Evento.hpp"

void arg(int argc, char *argv) {  //
    fprintf(stderr, "arg[\%i] = <\%s>\n", argc, argv);
}

int main(int argc, char *argv[]) {  //
    arg(0, argv[0]);
    for (int i = 1; i < argc; i++) {  //
        arg(i, argv[i]);
    }
}
""")

let lex: unit = //
    let H = $"#include \"{APP}.hpp\""
    File.WriteAllText($"src/{APP}.lex", 
    "%{\n    "+H+"\n%}\n\n%option noyywrap yylineno\n\n%%\n" )

let yacc: unit = //
    let H = $"#include \"{APP}.hpp\""
    File.WriteAllText($"src/{APP}.yacc", 
    "%{\n    "+H+"\n%}\n\n%%\nsyntax:\n" )
