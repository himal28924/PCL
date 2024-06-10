#r "nuget: FSharp.Data"

open FSharp.Data

type ProgrammingLanguages = 
    HtmlProvider <"https://en.wikipedia.org/wiki/Comparison_of_programming_languages"> 

ProgrammingLanguages.GetSample().Tables.``General comparisonedit``.Rows
    |> Seq.iter (fun item -> printf "%s: Original Purpose: %s  functional:%s \n ?" item.Language item.``Original purpose`` item.Functional )

ProgrammingLanguages.GetSample().Tables.``General comparisonedit``.Rows
    |> Seq.filter (fun item -> item.Functional = "Yes") // Filter for functional languages
    |> Seq.iter (fun item -> 
        printf "%s: Original Purpose: %s, Functional: %s \n" 
            item.Language 
            item.``Original purpose`` 
            item.Functional)


