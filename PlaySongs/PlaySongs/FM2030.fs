module FM2030


open FSound.Utilities
open FSound.Signal
open FSound.IO
open FSound.Filter

let sr = 44100.

let song = 
    let rootHz = 440.
    let volume = 6000.

    let trans semi = List.map (fun s -> s + semi)

    let acc() = makeSinPhaseAccum()
    
    let env gen p =  modulate (gen p) (adsr 0.0 1.0 0.03 0.05 0.00 0.8)

    let longAttack gen p =  modulate (gen p) (adsr 0.3 1.0 0.3 0.9 0.10 0.6)

    let pMod t=
        let pitchModHz= 8.0
        let pitchModPhase = 0.0
        let sinModAccum = makeSinPhaseAccum()
        1.0 + 0.03*(sinModAccum 1.0 pitchModHz pitchModPhase t)
    

    let flute acc p t= acc volume (rootHz * p * (pMod t)) 0.0 t

    let flute2 acc p t= acc volume (rootHz * p * (pMod t)) 0.0 t

    let fluteNotes n semi gen= (env(flute gen),   n,   [1;5;5;0; -4;1;3;1] |> trans semi)

    let fluteNotes4 n semi gen= (env(flute gen),   n,   [1;1;1;1;5;5;5;5;0;0;0;0; -4;-4;-4;-4;1;1;1;1;3;3;3;3;1;1;1;1] |> trans semi)

    let longFluteNotes n  semi acc= (longAttack(flute2 acc),   n,   [1;5;5;0; -4;1;3;1] |> trans semi)

    
    let A = ( 12.0, [ longFluteNotes 8 0 (acc()); ])

    let B = ( 12.0, [ fluteNotes 32 12 (acc()); longFluteNotes 8 0 (acc()); ])

    let C = ( 12.0, [ fluteNotes 32 12 (acc()); fluteNotes 32 24 (acc()); fluteNotes 12 12 (acc()); fluteNotes 48 24 (acc()); longFluteNotes 8 -12 (acc()); longFluteNotes 4 -24 (acc()); longFluteNotes 32 12 (acc()); ])

    let D = ( 12.0, [fluteNotes 32 12 (acc()); fluteNotes 32 24 (acc()); fluteNotes4 64 12 (acc()); fluteNotes4 24 -12 (acc()); fluteNotes 24 -24 (acc()); longFluteNotes 8 -12 (acc()); longFluteNotes 4 -24 (acc());])
    

    [| A; B; C; D; C; D;|]
    |> songToWaveGen
    
let play () =
    let (duration, songGen) = song
    let x = async {do! Async.Sleep(1010 * (int duration))}
    playWave sr duration songGen
    Async.RunSynchronously(x)
    

let save name =
    let (t,gen) = song
    streamToWavMono 44100 2 name (generate sr t (gen))
