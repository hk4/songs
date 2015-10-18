

[<EntryPoint>]
let main argv = 

    //FirstSong.play()
    //IAmWeird.play()
    //TiggerSong.play()
    InteriorSounds.save "InteriorSounds.wav"

    printfn "%A" argv
    System.Console.ReadKey() |> ignore
    0 // return an integer exit code
