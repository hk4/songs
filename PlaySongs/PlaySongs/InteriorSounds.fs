module InteriorSounds

open FSound.Play
open FSound.Utilities
open FSound.Signal
open FSound.Filter
open FSound.IO



let save filename =

    let rootHz = 220.0
    let volume = 5000.
    let sr = 44100.0


    let mel p = modulate (triangle (volume*0.4) (2.0 * rootHz * p)) (adsr 0.0 1.0 (p*0.05) 0.00 0.0 0.0) >> delay sr 2.0 (200.*p) 0.9 (0.5*p)

    let sub p = modulate (sinusoid (volume*0.4) ( rootHz * p) 0.0) (adsr 0.0 1.0 0.05 0.08 0.1 0.15)

    let trump p = modulate (saw (volume*0.3) ( rootHz *0.5 * p) ) (adsr 0.1 1.0 0.01 0.1 0.2 2.15) >> delay sr 2.0 (333.333*p) 0.50 0.4

    let hat em =  modulate (whiteNoise (volume*0.3)) (adsr 0.0 em 0.05 0.08 0.1 0.15)

    let snip em =  modulate (whiteNoise (volume*0.3)) (adsr 0.0 em 0.01 0.00 0.0 0.15)
    
    let infiniteOf repeatedList = 
        Seq.initInfinite (fun _ -> repeatedList) 
            |> Seq.concat
    
    let score =
        ( 42.0,
            [
                (mel,   256,   [0;7;0;3]);
                (mel,   256*2, [ 0;-7;-20; -19;0; -5;-3;]);
                (hat,   256,   [12;0;-24]);
                (hat,   64,    [    24;   12;      12;  12;                ])  ;
                (hat,   128*3, [    12;    0;       0;   0;    0;     0;])  ;
                (snip,  256*3, [   -12;    0;     -24; -24;  -24;   -24;])  ;
                (sub,   256,   [   -12;    7;       4;   1;    0;])  ;
                (trump, 16,    [   -12;  -12;     -15; -15;  -4;   -4;  -5; -2; 10;  -12; 4;  36;] );
            ]
        )

    
    let saveGen path sr time waveformGen=
      waveformGen
      |> generate sr time
      |> floatTo16
      |> makeSoundFile sr 1 16 true
      |> toWav path

    let (length, parts) = score
    parts
    |> List.map (fun (gen, n, pArr) -> infiniteOf (pArr) |> Seq.take n |> Seq.map (float >> transpose >> gen))
    |> List.map (fun gen -> sequencer (Array.ofSeq gen) length )
    |> sum
    |> saveGen filename sr (length*2.0)
    //|> playWave sr (length * 2.0)




