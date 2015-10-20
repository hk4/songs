module IAmWeird

open FSound.Play
open FSound.Utilities
open FSound.Signal



let play () =

    let note = 440.0
    let volume = 5000.0
    let sr = 44100.0

    let pingAdsr gen = modulate gen (adsr 0.0 1.0 0.05 0.08 0.1 0.15) 

    let flute pitchMult = pingAdsr (triangle volume (2.0 * note * pitchMult))

    let horn pitchMult = pingAdsr (saw volume (note * pitchMult))
    let notes =
    
        [|
            0; 4;   5;   9;
            7; 5;   5;   3; 
            -12; 2; 14; -24;
            0; 7;   7;  12;
        |] 
    let pat1 = notes |> Array.map(float >> FSound.Utilities.transpose >> flute) 
    let pat2 = notes |> Array.map(float >> FSound.Utilities.transpose >> horn) 
    
    let loopSeconds = 1.4

    let sumSeq loopSeconds gensList  = sum ( gensList |> Seq.map(fun gen -> sequencer gen loopSeconds ))

    let a = sumSeq loopSeconds [pat1]
    let b = sumSeq (loopSeconds*2.0) [pat2]
    let c = sumSeq (loopSeconds*2.0) [[|a|];[|b|];]

    sequencer [|a;a;a;a; b;b;b;b; c;c;c;c; b;b;b;b|] (loopSeconds * 16.0) 
    |> playWave sr (loopSeconds * 16.0 * 4.0 )
