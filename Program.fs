module wordcounter =
        open System
        open System.IO
        open System.Text.RegularExpressions
        
        let setCommandLineArgs() =
                let arr = Environment.GetCommandLineArgs() //SIDE EFFECT: takes 2 arguments, if more or less, the error is not caught
                (arr[1], arr[2]) //tuple

        let (pathInput, fileExtensionInput) = setCommandLineArgs()

        //relative path is set and file Extension is set correctly for later
        let (path, fileExtension) = (__SOURCE_DIRECTORY__ + pathInput, "*" + fileExtensionInput)

        let files =
                Directory.EnumerateFiles(path, fileExtension, SearchOption.AllDirectories) //SIDE EFFECT: might throw exception
                |> Seq.map (fun path -> (File.ReadAllText(path)))

        let filesConcat = String.Concat(files)

        let wordCount (s) =
                let pattern = "[A-Za-z]+"
                Regex.Matches(s, pattern, RegexOptions.IgnoreCase)
                |> Seq.cast<Match>
                |> Seq.map (fun m -> m.ToString())
                |> Seq.groupBy id
                |> Seq.map (fun (k,v) -> k,Seq.length v)
                |> Seq.sortBy (fun (_,v) -> -v)
        
        // Output, not functional!
        let lines = wordCount filesConcat |> Seq.map (fun (w, c) -> sprintf "%s: %i" w c)
        File.WriteAllLines(__SOURCE_DIRECTORY__ + @"\result.csv", lines)