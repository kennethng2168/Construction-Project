import 'package:flutter/material.dart';

import '../../constraints.dart';

class DroneStatus extends StatelessWidget {
  const DroneStatus({
    Key? key,
    required this.constrains,
  }) : super(key: key);

  final BoxConstraints constrains;

  @override
  Widget build(BuildContext context) {
    return Column(
      children: [
        Padding(
          padding: EdgeInsets.all(15.0),
        ),
        Text(
          "GPS",
          style: TextStyle(fontSize: 50, fontWeight: FontWeight.normal),
        ),
        const SizedBox(height: 10),
        Container(
            child: CircleAvatar(
          backgroundColor: Color.fromRGBO(0, 22, 68, 1),
          child: Image.asset(
            "assets/images/deltaAPU-back.png",
            fit: BoxFit.cover,
            width: 800,
            height: 800,
          ),
          maxRadius: 60,
        )),
        Column(
          children: [
            Padding(
              padding: EdgeInsets.all(5.0),
            ),
            Text(
              "Current Location",
              style: TextStyle(
                fontSize: 25,
              ),
            ),
            Text(
              "Kuala Lumpur",
              style: TextStyle(
                fontSize: 20,
              ),
            ),
          ],
        ),
        // Row(
        //   mainAxisAlignment: MainAxisAlignment.start,
        //   children: [
        //     Padding(
        //       padding: EdgeInsets.all(15.0),
        //     ),
        //     Text(
        //       "Latitude: ",
        //       style: TextStyle(
        //         fontSize: 20,
        //       ),
        //       textAlign: TextAlign.center,
        //     ),
        //     Text(
        //       "123.456789",
        //       style: TextStyle(
        //         fontSize: 20,
        //       ),
        //       textAlign: TextAlign.center,
        //     ),
        //   ],
        // ),
        const Spacer(),
        Text(
          "current mode".toUpperCase(),
          style: const TextStyle(
            fontSize: 20,
            fontWeight: FontWeight.bold,
          ),
        ),
        const Text(
          "Stabalize",
          style: TextStyle(fontSize: 20),
        ),
        SizedBox(
          height: constrains.maxHeight * 0.14,
        ),
        DefaultTextStyle(
          style: const TextStyle(
            fontSize: 18,
            fontWeight: FontWeight.bold,
          ),
          child: Row(
            mainAxisAlignment: MainAxisAlignment.spaceEvenly,
            children: const [Text("Velocity(m/s)"), Text("Remaining Power")],
          ),
        ),
        const SizedBox(
          height: defaultPadding,
        ),
      ],
    );
  }
}
