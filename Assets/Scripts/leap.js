const Leap = require('leapjs'); 
const osc = require("osc");

const udpPort = new osc.UDPPort({
    localAddress: "127.0.0.1",
    localPort: 3333,
    remoteAddress: "127.0.0.1",
    remotePort: 3334,
    metadata: true
});

udpPort.open();

const controller = Leap.loop(function(frame){
    if (frame.hands.length > 0) {
        const hand = frame.hands[0];
        const height = hand.palmPosition[1]; // 50 .. 450 [mm]
        const pitch = hand.pitch();     // -PI .. PI
        const roll = hand.roll();       // -PI .. PI

        
        
        const msg = {
            address: "/leap",
            args: [
                {
                    type: "f",
                    value: height
                },
                {
                    type: "f",
                    value: pitch
                },
                {
                    type: "f",
                    value: roll
                }
            ]
        };
        console.log(msg.address, msg.args);
        udpPort.send(msg);
    }
});
