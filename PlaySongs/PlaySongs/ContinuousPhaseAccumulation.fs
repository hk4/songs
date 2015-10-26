module ContinuousPhaseAccumulation


open FSound.Utilities
open FSound.Signal
open FSound.IO
open FSound.Filter

let sr = 44100.

let song = 
    let rootHz = 440.
    let volume = 8000.
    let t semi = List.map (fun s -> s + semi)

    let normalSinInstrument p = modulate (sinusoid (volume*0.38) (2.0 * rootHz * p) 0.0 ) (adsr 0.0 1.0 (p*0.05) 0.18 0.04 0.9)

    let normalSinNotes n = (normalSinInstrument,   n,   [7;5;3;3; 15;17;-12;1])
    
    let normalPat = ( 6.0, [ normalSinNotes 12; ])
    
    let newSinWaveGen = makeSinPhaseAccum()

    let newSinInstrument p = modulate (newSinWaveGen (volume*0.38) (2.0 * rootHz * p) 0.0 ) (adsr 0.0 1.0 (p*0.05) 0.18 0.04 0.9)

    let newSinNotes n = (newSinInstrument,   n,   [7;5;3;3; 15;17;-12;1])

    let newPat = ( 6.0, [ newSinNotes 12; ])

    let normalKick p t = sinusoid volume (rootHz * p * (adsr 0.0 1.0 0.02 (1.0/4.0) 0.05 2.0 t)) t t

    let newKickSinusoid = makeSinPhaseAccum()

    let newKick p t = newKickSinusoid volume (rootHz * p * (adsr 0.0 1.0 0.02 (1.0/4.0) 0.05 2.0 t)) t t

    let normalKickNotes n = (normalKick,   n,   [0])

    let newKickNotes n = (newKick,   n,   [0])

    let normalKickPat =  ( 6.0, [ normalKickNotes 12; ])

    let newKickPat =  ( 6.0, [ newKickNotes 12; ])

    [| newKickPat; normalKickPat|]
    |> songToWaveGen
    
let play () =
    let (duration, songGen) = song
    let x = async {do! Async.Sleep(1010 * (int duration))}
    playWave sr duration songGen
    Async.RunSynchronously(x)
    

let save name =
    let (t,gen) = song
    streamToWavMono 44100 2 name (generate sr t (gen))
