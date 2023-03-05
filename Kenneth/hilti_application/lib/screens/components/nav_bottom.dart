import 'package:flutter/material.dart';
import 'package:flutter_svg/flutter_svg.dart';
import '../../constraints.dart';

class TeslaBottomNavigationBar extends StatelessWidget {
  const TeslaBottomNavigationBar({
    Key? key,
    required this.selectedTab,
    required this.onTap,
  }) : super(key: key);

  final int selectedTab;
  final ValueChanged<int> onTap;

  @override
  Widget build(BuildContext context) {
    return BottomNavigationBar(
      onTap: onTap,
      currentIndex: selectedTab,
      type: BottomNavigationBarType.fixed,
      backgroundColor: Colors.black,
      items: List.generate(
        navIconSrc.length,
        (index) => BottomNavigationBarItem(
          icon: Container(
            height: 35,
            width: 35,
            child: SvgPicture.asset(
              navIconSrc[index],
              color: index == selectedTab ? primaryColor : Colors.white54,
            ),
          ),
          label: "",
        ),
      ),
    );
  }
}

List<String> navIconSrc = [
  "assets/icons/bulbon.svg",
  "assets/icons/drone.svg",
];
