bigint
======

BigInt via logic gate emulation - proof of concept.
----------------------------------------------------

We have classes like "and", "or"... combined in "adder" and then
chained in n-bit adder. Using that we are able to calculate sum
of two big numerals (repersented as binary).

Current implementation uses stack heavily which causes limitation
for the numerals of about 10^1000 in my environment.
