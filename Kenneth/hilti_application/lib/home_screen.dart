import 'package:flutter/material.dart';
import 'package:hilti_application/screens/home_screen.dart';

import 'const.dart';
import 'model.dart';
import 'screens/components/background_gradient_image.dart';
import 'screens/components/dark_borderless_button.dart';
import 'screens/components/location_card.dart';
import 'screens/components/primary_rounder_button.dart';
import 'screens/components/red_rounded_action_button.dart';

class MyHomePage extends StatefulWidget {
  int index = 1;

  MyHomePage({Key? key}) : super(key: key);
  @override
  _MyHomePageState createState() => _MyHomePageState();
}

class _MyHomePageState extends State<MyHomePage> {
  @override
  Widget build(BuildContext context) {
    final String backgroundImage = movies[widget.index].image;
    final String title = movies[widget.index].title;
    final String age = movies[widget.index].age;
    final String rating = movies[widget.index].rating.toString();
    final String year = movies[widget.index].date.year.toString();
    final String categories = movies[widget.index].categorires;
    final String technology = movies[widget.index].technology;

    return Scaffold(
      resizeToAvoidBottomInset: false,
      body: Stack(
        fit: StackFit.expand,
        children: <Widget>[
          BackgroundGradientImage(
            image: Image.asset(
              backgroundImage,
              fit: BoxFit.cover,
            ),
          ),
          SafeArea(
            child: Column(
              children: [
                // const Padding(padding: EdgeInsets.all(10.0)),
                // const MovieAppBar(),
                // const Padding(padding: EdgeInsets.symmetric(vertical: 50.0)),
                Container(
                  height: 350,
                  child: Image.asset(
                    "assets/images/deltaAPU-back.png",
                    fit: BoxFit.fitHeight,
                  ),
                ),
                // Image.asset(
                //   "assets/images/deltaAPU-back.png",
                // ),
                // const Text(
                //   "OmniTwin",
                //   style: TextStyle(
                //     fontSize: 50,
                //     fontWeight: FontWeight.bold,
                //   ),
                // ),

                // Image.asset(movies[widget.index].logo),
                // const Padding(padding: EdgeInsets.symmetric(vertical: 10.0)),
                Row(
                  mainAxisAlignment: MainAxisAlignment.spaceEvenly,
                  children: <Widget>[
                    DarkBorderlessButton(
                      text: title,
                      callback: () {},
                    ),
                    // DarkBorderlessButton(text: age, callback: () {}),
                    PrimaryRoundedButton(
                      text: rating,
                      callback: () {},
                    ),
                  ],
                ),
                Padding(
                  padding: const EdgeInsets.symmetric(
                      vertical: 20.0, horizontal: 10.0),
                  child: SingleChildScrollView(
                    scrollDirection: Axis.horizontal,
                    child: Row(
                      mainAxisAlignment: MainAxisAlignment.spaceEvenly,
                      children: <Widget>[
                        Text(
                          year,
                          style: kSmallMainTextStyle,
                        ),
                        // Text('•', style: kPromaryColorTextStyle),
                        // Text(
                        //   categories,
                        //   style: kSmallMainTextStyle,
                        //   overflow: TextOverflow.ellipsis,
                        // ),
                        Text('•', style: kPromaryColorTextStyle),
                        Text(technology, style: kSmallMainTextStyle),
                      ],
                    ),
                  ),
                ),
                Image.asset('assets/images/divider.png'),
                RedRoundedActionButton(
                    text: 'View Details',
                    callback: () {
                      Navigator.of(context).push(
                        MaterialPageRoute(
                          builder: (context) => HomeScreen(),
                        ),
                      );
                    }),
                Expanded(
                    child: ListView.builder(
                        scrollDirection: Axis.horizontal,
                        shrinkWrap: true,
                        itemCount: movies.length,
                        itemBuilder: (context, index) {
                          return LocationCard(
                              title: title,
                              imageLink: movies[index].image,
                              active: index == widget.index ? true : false,
                              callBack: () {
                                setState(() {
                                  widget.index = index;
                                });
                              });
                        })),
              ],
            ),
          ),
        ],
      ),
    );
  }
}
