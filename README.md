# William's Songs made with FSound

## Synopsis

This is William Sharkey's fork of [FSound](https://github.com/albertp007/FSound).

FSound was created by Albert Pang (albert.pang@me.com). FSound is a library for processing sound using F#.

The purpose of this repository is to showcase songs that I made with FSound.

While making songs, I add a few utility methods help me, like sequence and transpose, that are currently not in the parent FSound repository. (as of Oct. 17, 2015)

Like the parent project, *William's Songs made with FSound* and code are licensed under GPL v3.0

## Songs

Newest First
### 2. FHouse - [click to play](http://williamsharkey.com/FSounds/FHouse.mp3)
(Oct - 18 - 2015)
FHouse is my second attempt at a song. It is unhelpfully named - it is really not house music at all. It sounds vaguely of aphex twin.
It makes use of a new feature - one is a weighted sequencer. It is a sequencer of generators that steps through generators in accordance to how many seconds is specified.
This allowed me to create separate song sections and tie them together.
Here is a screenshot of some code:
![F# Code Example- FHouse](http://williamsharkey.com/FSounds/FHouse.png)
I am not totally happy with it, but I think it is a big improvement over *Interior Sounds* -- because it has separate sections -- instead of a monotonous loop.


### 1. Interior Sounds - [click to play](http://algoind.com/live/FSounds/InteriorSounds.mp3) 
(Oct - 17 - 2015)
Interior sounds is a loopy minimal electronic song. 
It makes use of [an infinite sequence](http://www.fssnip.net/a5) generator to loop note sequences of different lengths. Here is the guts of the composition: 

![F# Code Example](http://algoind.com/live/FSounds/InteriorSounds.png)

The score is essentially an array of tuples (instrument, noteCount, control-voltage-array)

For most of the instruments, control-voltage controls to the pitch.

The pitches are actually given in semitones in this example, then converted to hz.

The 42.0 sets the length of the loop -- 42 seconds.

The 256 number next to mel instructs the program to:
```
subdivide the 42 seconds into 256 parts,
generate 256 sounds with the mel generator
taking pitch values sequentially from the  from the list [0;7;0;3]
```
For more context, download the project and see the full source code!

## Code Example

Here are some of the things you can do with FSound:

* Generate a .wav file containing a sawtooth wave of amplitude 10000, 440Hz, 
sampling rate 44100Hz, 1 channel, 16-bit sample and which lasts for 2 seconds
  
  ```
  open FSound.Signal
  open FSound.IO
  
  saw 10000.0 440.0
  |> generate 44100.0 2.0
  |> floatTo16
  |> makeSoundFile 44100.0 1 16 true
  |> toWav @"blah.wav";;
  ```

* Play a triangular wave of amplitude 10000, 440Hz, sampling rate 44100Hz, 1 channel and which lasts for 2 seconds
  
  ```
  open FSound.Signal
  open FSound.Utilities
  
  triangle 10000.0 440.0 |> playWave 44100.0 2.0
  ```

* Add an ADSR envelope to the triangular wave above
  
  ```
  open FSound.Signal
  open FSound.Utilities
  
  modulate (triangle 20000.0 2000.0) (adsr 0.05 1.0 0.05 0.3 0.1 0.05)
  |> playWave 44100.0 1.0
  ```

* Add 200ms delay, 50/50 dry/wet and 0.15 feedback gain to the triangular wave with an ADSR envelope above

  ```
  open FSound.Signal
  open FSound.Filter
  open FSound.Utilities
  
  modulate (triangle 20000.0 2000.0) (adsr 0.05 1.0 0.05 0.3 0.1 0.05)
  >> delay 44100.0 2.0 200.0 0.15 0.5
  |> playWave 44100.0 1.0
  ```
  
* The same as right above, except replace triangular wave with white noise to produce the sound of shuffling something

  ```
  open FSound.Signal
  open FSound.Filter
  open FSound.Utilities
  
  modulate (whiteNoise 20000.0) (adsr 0.05 1.0 0.05 0.3 0.1 0.05)
  >> delay 44100.0 2.0 200.0 0.15 0.5
  |> playWave 44100.0 1.0
  ```

* Shaping white noise with a Smith-Angell resonator

  ```
  open FSound.Signal
  open FSound.Filter
  open FSound.Utilities
  
  whiteNoise 50000.0 
  >> smithAngell 44100.0 440.0 10.0
  |> playWave 44100.0 2.0
  ```

* Shaping white noise first with an ADSR envelope then a Smith-Angell resonator

  ```
  open FSound.Signal
  open FSound.Filter
  open FSound.Utilities
  
  modulate (whiteNoise 50000.0) (adsr 0.05 1.0 0.05 0.3 0.1 0.05)
  >> smithAngell 44100.0 880.0 10.0
  |> playWave 44100.0 2.0
  ```

* Generate white noise and pass through a high-pass filter

  ```
  open FSound.Signal
  open FSound.Filter
  open FSound.Utilities
  
  whiteNoise 10000.0 
  >> hp 44100.0 10000.0
  |> playWave 44100.0 1.0
  ```
  
* Modulate amplitude of white noise with an LFO and pass through a low-pass filter - A crude simulation to the sound of waves

  ```
  open FSound.Signal
  open FSound.Filter
  open FSound.Utilities
  
  modulate (whiteNoise 10000.0) (lfo 0.05 0.8)
  >> lp 44100.0 220.0
  |> playWave 44100.0 50.0
  ```
  
* Generate 1 sec of white noise samples, pass them through a low-pass filter and plot the frequency spectrum up to 20000Hz

  ```
  open FSound.Signal
  open FSound.Filter
  open FSound.Plot
  
  whiteNoise 10000.0
  >> lp 44100.0 220.0
  |> generate 44100.0 1.0
  |> plotFreq 20000
  ```
  
* Vibrato on a triangular wave
  
  ```
  open FSound.Signal;;
  open FSound.Filter;;
  open FSound.Utilities;;
  triangle 10000.0 440.0 
  >> vibrato 44100.0 7.0 2.0 
  |> playWave 44100.0 5.0
  ```
  
* Flanging on saw wave

  ```
  open FSound.Signal;;
  open FSound.Filter;;
  open FSound.Utilities;;
  saw 10000.0 440.0
  >> flanger 44100.0 7.0 0.15 0.5 0.2
  |> playWave 44100.0 10.0
  ```


* Flanging on white noise

  ```
  open FSound.Signal;;
  open FSound.Filter;;
  open FSound.Utilities;;
  whiteNoise 10000.0
  >> flanger 44100.0 7.0 0.15 0.5 0.2
  |> playWave 44100.0 10.0
  ```
  
## Motivation

This project arises purely out of a personal interest in learning the F#
programming language and applying to a domain I have always found fascinating -
Sound.


## Installation

Simply download the project and load it in visual studio 2015.

If your version of Visual Studio does not have F#,  you may 
install the free Visual Studio 2015 Community Edition. 
The Visual F# Tools are installed automatically when you first 
create or open an F# project. See: http://fsharp.org/use/windows/

This project requires you to install the NAudio package. 
To do this with Nu-Get in VS:
1. Right click References in Solution Explorer 
2. Click Manage Nu-Get packages
3. Search for NAudio
4. Uninstall then Install NAudio


## Tests

SignalTest.fsx is the only test script for now.  Load it into F# interactive:
```
C:\Users\panga\project\fsharp\FSound>fsi --load:SignalTest.fsx

Microsoft (R) F# Interactive version 14.0.23020.0
Copyright (c) Microsoft Corporation. All Rights Reserved.

For help type #help;;

[Loading C:\Users\panga\project\fsharp\FSound\SignalTest.fsx]

namespace FSI_0002
  val testWaveform : waveformGen:seq<float> -> path:string -> unit
  val testSinusoid : unit -> unit
  val testSquare : unit -> unit
  val testSaw : unit -> unit
  val testTriangle : unit -> unit
  val testNoise : unit -> unit
  val testWave : unit -> unit
  val testRead : unit -> bool
  val test : unit -> unit

> SignalTest.test();;
val it : unit = ()

> exit 0;;

C:\Users\panga\project\fsharp\FSound>dir *.wav
 Volume in drive C has no label.
 Directory of C:\Users\panga\project\fsharp\FSound

01/09/15  07:17 pm           176,446 saw-440.wav
01/09/15  07:17 pm           176,446 sinusoid-440.wav
01/09/15  07:17 pm           176,446 square-440.wav
01/09/15  07:17 pm           176,446 triangle-440.wav
01/09/15  07:17 pm           882,046 wave.wav
01/09/15  07:17 pm           176,446 whitenoise.wav
               6 File(s)      1,764,276 bytes
               0 Dir(s)  30,879,870,976 bytes free
```
## Contributors
Albert Pang (albert.pang@me.com)


## License

Released under GPL v3.0 licence
