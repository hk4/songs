module ElleElision

open FSound.Utilities
open FSound.Signal
open FSound.Filter

let sr = 44100.

let song = 
    let rootHz = 210.
    let volume = 8000.
    let t semi = List.map (fun s -> s + semi)

    let instrument p = modulate (triangle (volume*0.18) (2.0 * rootHz * p) ) (adsr 0.0 1.0 (p*0.05) 0.10 0.0 0.9)

    let instrument2 p = modulate (triangle (volume*0.18) (2.0 * rootHz * p) >> chorus sr 10.0 0.4 0.8 ) (adsr 0.0 1.0 (p*0.05) 0.10 0.0 0.9) >> delay 44100.0 6.0 (8000./26.) 0.80 0.3

    let mel n s= (instrument,   n,   [0;9;2;11; 4;12;5;14; -5;19;-1;17; 12;] |> t s )
    let mel2 n s= (instrument2,   n,   [0;9;2;11; 4;12;5;14; -5;19;-1;17; 12;] |> t s )
    let melB n s= (instrument,   n,   [0;0;9;9;2;2;11;11; 4;4;12;12;5;5;14;14; -5;-5;19;19;-1;-1;17;17;12; 12;] |> t s )

    let melOut n s= (instrument2,   n, [0;0;0;0; 0;0;0;0;-12;-48;-48;-48;-48;] |> t s )
    
    let a = ( 16.0, [ mel 26 0;])
    let b = ( 16.0, [ mel 26 -12; mel 22 0])
    let c = ( 16.0, [ mel 25 -12; mel 20 0; mel 8 12])
    let d = ( 16.0, [ mel 24 12; mel 36 -12; mel 12 12; mel 6 24])

    let A = ( 16.0, [ mel 26 0; melB 52 -12; melB 13 -24])
    let B = ( 16.0, [ mel 26 -12; mel2 22 0; melB 44 -12])
    let C = ( 16.0, [ mel 25 -12; mel2 20 0; mel2 8 12; melB 50 -12])
    let D = ( 16.0, [ mel 24 12; mel2 36 -12; mel2 12 12; mel2 6 24; melB 72 -12])

    let outro = ( 8.0, [ melOut 13 0;])

    [|a;b;c;d;C;D;outro|]
    |> songToWaveGen
    
let play () =
    let (duration, songGen) = song
    playWave sr duration songGen

let save name =
    song |>  makeWavFileFromWaveformGen name sr

