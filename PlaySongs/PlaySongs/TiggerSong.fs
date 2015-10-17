module TiggerSong

open FSound.Play
open FSound.Utilities
open FSound.Signal



let play () =

    let rootHz = 300.0
    let volume = 5000.0
    let sr = 44100.0


    let hatAdsr gen emp = modulate gen (adsr (0.005/emp) (emp*0.7) (0.1/emp) (0.04*emp) 0.1 0.15) 

    let hat emphasis = hatAdsr (whiteNoise volume) emphasis

    let q = 0.3

    let rythmnScore =
    
        [|
            5.1; 2.0;  2.;  q;   1.; q;      2.; q;
            3.1;   q;  2.;  q;   1.; q;      2.; q;
            0.8; 1.2;  2.;  q;   1.; q;      2.; q;
            3.1;   q;  2.; 2.;   1.; 2.0;    2.; q;
        |] 

    let rhytmnPat = rythmnScore |> Array.map(float >> hat) 

    let fluteAdsr gen = modulate gen (adsr 0.0 1.0 0.05 0.08 0.1 0.15) 

    let bassAdsr gen = modulate gen (adsr 0.05 1.0 0.09 0.8 0.4 0.35) 
    
    let flute pitchMult = fluteAdsr (triangle (volume*0.7) (2.0 * rootHz * pitchMult))

    let bass pitchMult = bassAdsr (sinusoid (volume*0.3) (rootHz * 0.25 * pitchMult) 0.0)

    let notes =
    
        [|
            0;   0;   5;     0;
            12;  12;   10;   8; 
            7;    7;    7;   7;
            0 ; 12;   7;     5;
        |] 

    let pat1 = notes |> Array.map(float >> FSound.Utilities.transpose >> flute) 

    let bassPat = notes |> Array.map(float >> FSound.Utilities.transpose >> bass) 
    //let pat2 = notes |> Array.map(float >> FSound.Utilities.transpose >> horn) 
    
    let loopSeconds = 5.0

    

    let sumSeq loopSeconds gensList  = sum ( gensList |> Seq.map(fun gen -> sequencer gen loopSeconds ))

    let bassStretch = sumSeq (loopSeconds*2.0) [bassPat;bassPat;bassPat;bassPat]
    let pat1Stretch = sumSeq (loopSeconds) [pat1]
    let rs = sumSeq (loopSeconds*0.5) [rhytmnPat]

    let a = sumSeq loopSeconds [rhytmnPat]
    let b = sumSeq loopSeconds [pat1; rhytmnPat]
    let c = sumSeq (loopSeconds*4.0) [pat1;[|rs;bassStretch|]; rhytmnPat ;[|bassStretch|]; bassPat]
    let d = sumSeq (loopSeconds*4.0) [[|c;bassStretch;rs|]; rhytmnPat ;[|bassStretch;rs|]; bassPat]
    sequencer [|a;a;b;b;c;c;c;c;d;d;d;d;b;b;a;a|] (loopSeconds * 32.0) 
    |> playWave sr (loopSeconds * 32.0 )
