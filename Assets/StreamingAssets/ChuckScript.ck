global Event Trigger;
global int Type;

OscIn oscIn;
OscMsg oscMsg;
3334 => oscIn.port; 
oscIn.addAddress("/leap,fff");

// SinOsc foo => ADSR env => LPF filter => NRev verb => dac;
//     Math.random2f( 300, 1000 ) => foo.freq;
//    100::ms => now;

SinOsc foo => dac;
while( true )
{
    oscIn => now;
    while (oscIn.recv(oscMsg)) {
        oscMsg.getFloat(0) => float height;
        oscMsg.getFloat(1) => float pitch;
        oscMsg.getFloat(2) => float roll;
        chout <= height <= "," <= pitch <= "," <= roll <= IO.newline();
    }
    
    
}
