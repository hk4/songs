module Prime

open FSound.Utilities
open FSound.Signal
open FSound.Filter
open FSound.Play

let save name =

    let rootHz = 220.
    let volume = 5000.
    let sr = 44100.

    let t semi = List.map (fun s -> s + semi)

    let insMel p = modulate (triangle (volume*0.18) (2.0 * rootHz * p)) (adsr 0.0 1.0 (p*0.05) 0.10 0.0 0.9)

    let insChord p = modulate (triangle (volume*0.6) (2.0 * rootHz * p)) (adsr 0.01 1.0 (0.5) 0.10 1.5 0.9)
    
    let bassChord p = modulate (saw (volume*0.5) ( rootHz * 0.5 * p)) (adsr 0.00 1.0 (0.01) 0.1 0.5 1.3) >> lp sr (rootHz * 0.5 * p)

    let insHat em =  modulate (whiteNoise (volume*0.12)) (adsr 0.0 em 0.05 0.08 0.1 0.15)

    let mel n s= (insMel,   n,   [0;9;3;7;7;15] |> t s )
    let hat n = (insHat,   n,   [0;9;3;7;7;15])
    
    
    let a = ( 8.0, [ mel 12 0; mel 12 -12;(insChord, 2,  [-3;]);(bassChord, 8,  [-5;]);(bassChord, 8,  [0;])])
    let b = ( 8.0, [ mel 16 0 ;(insChord, 2,  [0;]) ;(bassChord, 2,  [-5;]);(bassChord, 16,  [7;])])
    let c = ( 8.0, [ hat 12; mel 12 -12;(insChord, 4,  [-5;]);(insChord, 8,  [-12;0;12;]);(bassChord, 16,  [-5;0;]);(bassChord, 32,  [0;3;5;7])])
    let d = ( 8.0, [ hat (8); mel 12 0 ;mel 4 7 ;mel 2 19;mel 6 24;(insChord, 16,  [7;5;3;]);
                    (insChord, 4,  [3;-12]);(bassChord, 16,  [3;12]);(bassChord, 16,  [7;3;12;15;0]);])
    let e = ( 8.0, [ hat 4; mel 8 -24 ;mel 4 7 ;mel 3 -3;mel 6 0;mel 12 -12;(bassChord, 8,  [-5;0;]);(bassChord, 16,  [15;15;12]);])
    let f = ( 8.0, [ hat 4; hat 8 ;hat 16; (insChord, 4, [0;]) ; (insChord, 4, [7]); (insChord, 4, [3]);
                    (bassChord, 5,  [7]);(bassChord, 16,  [7]);(bassChord, 16,  [-5]);])
    let g = ( 8.0, [ hat 16; mel 32 0 ; (insChord, 4,  [0;]) ;(insChord, 8,  [-12]); (insChord, 4, [7]); 
                    (insChord, 4,  [3]);(bassChord, 16,  [-3;0;15]);(bassChord, 16,  [-15;12;7;-12]) ])
    let h = ( 8.0, [ hat 8;hat 64; hat 128; mel 32 0 ;mel 32 -12 ;mel 64 -24 ; (insChord, 4,  [0;]);
                    (insChord, 8,  [-12;-5;7;0]); (insChord, 32,  [7;5;3;0]);
                    (insChord, 16,  [3;0;1]) ;(bassChord, 32,  [3;3;11;12]);(bassChord, 32,  [3;3;-12])])
    
    let patterns = [|a;a;b;b;c;c;e;e;d;d;f;f;g;g;d;d;h;h;a;a|] 
    
   
    patterns |> songToWaveGen |> makeWavFileFromWaveformGen name sr 

    //let (d,g) = patterns |> songToWaveGen
    //playWave sr d g
    
     

