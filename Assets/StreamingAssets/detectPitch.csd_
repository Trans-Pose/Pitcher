<Cabbage>
</Cabbage>
<CsoundSynthesizer>
<CsOptions>
-n -+rtmidi=NULL -M0 -m0d
</CsOptions>
<CsInstruments>
; Initialize the global variables. 
sr = 41000
ksmps = 32
nchnls = 2
0dbfs = 1


instr 1

iupdte = 0.001	;high definition
ilo = 6
ihi = 10
idbthresh = 10
ifrqs = 12
iconf = 10
istrt = 8

a1 inch 1
a2 inch 2
kp, ka pitchamdf a1, 100, 1000
String sprintfk "frequency in Hz : %f \n", kp
puts String, kp

;koct, kamp pitch a1, iupdte, ilo, ihi, idbthresh, ifrqs, iconf, istrt
;String sprintfk "frequency in oct : %f \n", koct
;puts String, koct

outs a1, a2
endin

</CsInstruments>
<CsScore>
;causes Csound to run for about 7000 years...
f0 z
;starts instrument 1 and runs it for a week
i1 0 [60*60*24*7] 
</CsScore>
</CsoundSynthesizer>
