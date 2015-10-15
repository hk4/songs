open FSound.Play
open FSound.Utilities
open FSound.Signal


[<EntryPoint>]
let main argv = 

    let note = 440.0
    let volume = 5000.0
    let sr = 44100.0

    let pingAdsr gen = modulate gen (adsr 0.05 1.0 0.05 0.3 0.1 0.05) 

    let flute pitchMult = pingAdsr (triangle volume (2.0 * note * pitchMult))

    let horn pitchMult = pingAdsr (saw volume (note * pitchMult))

    let pat1 = [1.0; 1.2; 1.3; 1.4; 1.0] |> List.map(flute) 
    let pat2 = [2.0; 2.4;] |> List.map(flute)
    let pat3 = [ 1.4; 1.3; 1.2; 1.1] |> List.map(flute) 
    let pat4 = [ 0.5;0.0;0.5;0.8;0.5;0.0;0.5;0.4;] |> List.map(flute) 
    let pat5 = [ 0.5;1.5;0.5;1.8;0.5;1.5;0.5;1.4;] |> List.map(horn) 
    
    let loopSeconds = 1.4

    let sumSeq loopSeconds gensList  = sum ( gensList |> List.map(fun gen -> sequencer gen loopSeconds ))

    let a = sumSeq loopSeconds [pat4]
    let b = sumSeq loopSeconds [pat1; pat4]
    let c = sumSeq loopSeconds [pat1; pat2; pat4]
    let d = sumSeq loopSeconds [pat1; pat2; pat3; pat4]
    let e = sumSeq loopSeconds [pat1; pat2; pat3; pat4; pat5]
    
    sequencer [a;a;a;a; b;b;c;c; b;b;d;d; e;e;e;e] (loopSeconds * 16.0) 
    |> playWave sr (loopSeconds * 16.0 * 4.0)


    printfn "%A" argv
    System.Console.ReadKey() |> ignore
    0 // return an integer exit code
