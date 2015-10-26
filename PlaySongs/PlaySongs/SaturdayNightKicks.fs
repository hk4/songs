module SaturdayNightKicks

open FSound.Utilities
open FSound.Signal
open FSound.IO
open FSound.Filter

let sr = 44100.

let song = 
    let rootHz = 440.
    let volume = 8000.
    let t semi = List.map (fun s -> s + semi)

    let kick p t = sinusoid volume (rootHz * p * (adsr 0.0 1.0 0.02 (1.0/4.0) 0.05 2.0 t)) 0.0 t
    
    let perc p t = sinusoid (volume * 0.1) (rootHz * p * 8.0 * (1.0 - (adsr 0.0 1.0 0.01 (1.0/16.0) 0.05 0.1 t))) 0.0 t

    let tiz p t = sinusoid (volume * 0.1) (rootHz * p * 32.0 * (1.0 - (adsr 0.0 1.0 0.1 (1.0/16.0) 0.05 0.1 t))) 0.0 t

    let tizEnv p =  modulate (tiz p) ( adsr 0.0 1.0 0.02 0.10 0.0 0.9)

    let bell p = modulate (triangle (volume*0.38) (2.0 * rootHz * p) ) (adsr 0.0 1.0 (p*0.05) 0.18 0.04 0.9)

    let subPat n = (kick,   n,   [-12;-7;-5])
    let kickPat n = (kick,   n,   [0])

    let percPat n = (perc,   n,   [0;3;1;5; 7;15])

    let tizPat n = ( tizEnv, n, [0;12;7])

    let bellPat n = (bell,   n,   [7;5;3;3; 15;17;-12;1])
    
    let a = ( 4.8, [ kickPat 8; subPat 3; bellPat 12; percPat 5; tizPat 16])
    
    [|a;a;a;a|]
    |> songToWaveGen
    
let play () =
    let (duration, songGen) = song
    let x = async {do! Async.Sleep(1010 * (int duration))}
    playWave sr duration songGen
    Async.RunSynchronously(x)
    

let save name =
    let (t,gen) = song
    streamToWavMono 44100 2 name (generate sr t (gen))//>> chorus sr 10.0 0.4 0.8 >> delay 44100.0 6.0 (8000./26.) 0.80 0.3)) //makeWavFileFromWaveformGen name 
