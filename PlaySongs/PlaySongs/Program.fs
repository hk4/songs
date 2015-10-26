

[<EntryPoint>]
let main argv = 
    let stamp =  System.DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".wav"
    //FirstSong.play()
    //IAmWeird.play()
    //TiggerSong.play()
    //InteriorSounds.save "InteriorSounds.wav"
    //FHouse.save "FHouse.wav"
    //Prime.save ("Prime/" + stamp)
    //ElleElision.play()
    //ElleElision.save ("ElleElision/"+stamp)
    //SaturdayNightKicks.save("SaturdayNightKicks/" + stamp)
    //SaturdayNightKicks.play()
    //ContinuousPhaseAccumulation.play()
    //FM2030.play()
    FM2030.save("FM2030/" + stamp)
    //printfn "%A" argv
    //System.Console.ReadKey() |> ignore
    0 // return an integer exit code
