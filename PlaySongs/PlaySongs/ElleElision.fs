module ElleElision

open FSound.Utilities
open FSound.Signal
open FSound.Filter

let sr = 44100.

let song = 
    let rootHz = 220.
    let volume = 5000.
    let t semi = List.map (fun s -> s + semi)

    let instrument p = modulate (triangle (volume*0.18) (2.0 * rootHz * p)) (adsr 0.0 1.0 (p*0.05) 0.10 0.0 0.9)

    let mel n s= (instrument,   n,   [0;9;2;11; 4;12;5;14; -5;19;-1;17; 12;] |> t s )
    
    let a = ( 16.0, [ mel 26 0;])
    let b = ( 16.0, [ mel 26 -12; mel 22 0])
    let c = ( 16.0, [ mel 25 -12; mel 20 0; mel 8 12])
    let d = ( 16.0, [ mel 24 12; mel 36 -12; mel 12 12; mel 6 24])
    [|a;b;c;d;b;a|]
    |> songToWaveGen
    
let play () =
    let (duration, songGen) = song
    playWave sr duration songGen

let save name =
    song |>  makeWavFileFromWaveformGen name sr

