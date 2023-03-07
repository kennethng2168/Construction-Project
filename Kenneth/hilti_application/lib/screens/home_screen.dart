import 'package:flutter/material.dart';
import 'package:flutter_svg/flutter_svg.dart';
import 'package:rive/rive.dart';

import '../Widgets/user_top_bar.dart';
import '../constraints.dart';
import '../home_controller.dart';
import 'components/drone_status.dart';
import 'components/door_lock.dart';
import 'components/nav_bottom.dart';

class HomeScreen extends StatefulWidget {
  HomeScreen({Key? key}) : super(key: key);

  @override
  State<HomeScreen> createState() => _HomeScreenState();
}

class _HomeScreenState extends State<HomeScreen>
    with SingleTickerProviderStateMixin {
  final HomeController _controller = HomeController();

  late AnimationController _DroneAnimationController;
  late Animation<double> _animationDrone;
  late Animation<double> _animationDroneStatus;

  void setupBatteryAnimation() {
    _DroneAnimationController = AnimationController(
      vsync: this,
      duration: const Duration(milliseconds: 600),
    );

    _animationDrone = CurvedAnimation(
      parent: _DroneAnimationController,
      curve: const Interval(0.0, 0.5),
    );

    _animationDroneStatus = CurvedAnimation(
      parent: _DroneAnimationController,
      curve: const Interval(0.6, 1),
    );
  }

  @override
  void initState() {
    setupBatteryAnimation();
    super.initState();
  }

  @override
  void dispose() {
    _DroneAnimationController.dispose();
    super.dispose();
  }

  @override
  Widget build(BuildContext context) {
    return AnimatedBuilder(
        animation: Listenable.merge([_controller, _DroneAnimationController]),
        builder: (context, _) {
          return Scaffold(
            bottomNavigationBar: TeslaBottomNavigationBar(
              onTap: (index) {
                if (index == 1) {
                  _DroneAnimationController.forward();
                } else if (_controller.selectedBottomTab == 1 && index != 1) {
                  _DroneAnimationController.reverse(from: 0.7);
                }
                _controller.onBottomNavigationTabChange(index);
              },
              selectedTab: _controller.selectedBottomTab,
            ),
            body: SafeArea(
              child: LayoutBuilder(
                builder: (context, constrains) {
                  return Stack(
                    alignment: Alignment.center,
                    children: [
                      RiveAnimation.asset(
                        "assets/images/digital_city.riv",
                        fit: BoxFit.fill,
                      ),

                      AnimatedPositioned(
                        duration: defaultDuration,
                        right: _controller.selectedBottomTab == 0
                            ? constrains.maxWidth * 0.05
                            : constrains.maxWidth / 2,
                        child: AnimatedOpacity(
                          duration: defaultDuration,
                          opacity: _controller.selectedBottomTab == 0 ? 1 : 0,
                          child: DoorLock(
                            isLock: _controller.isRightDoorLock,
                            press: _controller.updateRightDoorLock,
                          ),
                        ),
                      ),
                      AnimatedPositioned(
                        duration: defaultDuration,
                        left: _controller.selectedBottomTab == 0
                            ? constrains.maxWidth * 0.05
                            : constrains.maxWidth / 2,
                        child: AnimatedOpacity(
                          duration: defaultDuration,
                          opacity: _controller.selectedBottomTab == 0 ? 1 : 0,
                          child: DoorLock(
                            isLock: _controller.isLeftDoorLock,
                            press: _controller.updateLeftDoorLock,
                          ),
                        ),
                      ),
                      AnimatedPositioned(
                        duration: defaultDuration,
                        top: _controller.selectedBottomTab == 0
                            ? constrains.maxHeight * 0.20
                            : constrains.maxHeight / 2,
                        child: AnimatedOpacity(
                          duration: defaultDuration,
                          opacity: _controller.selectedBottomTab == 0 ? 1 : 0,
                          child: DoorLock(
                            isLock: _controller.isBonnetLock,
                            press: _controller.updateBonnetDoorLock,
                          ),
                        ),
                      ),
                      AnimatedPositioned(
                        duration: defaultDuration,
                        bottom: _controller.selectedBottomTab == 0
                            ? constrains.maxHeight * 0.20
                            : constrains.maxHeight / 2,
                        child: AnimatedOpacity(
                          duration: defaultDuration,
                          opacity: _controller.selectedBottomTab == 0 ? 1 : 0,
                          child: DoorLock(
                            isLock: _controller.isTrunkLock,
                            press: _controller.updateTrunkDoorLock,
                          ),
                        ),
                      ),
                      //Drone
                      Opacity(
                        opacity: _animationDrone.value,
                        child: Image.asset(
                          "assets/images/hexacopter.png",
                          width: 400,
                        ),
                      ),
                      Positioned(
                        top: 50 * (1 - _animationDroneStatus.value),
                        height: constrains.maxHeight,
                        width: constrains.maxWidth,
                        child: Opacity(
                          opacity: _animationDroneStatus.value,
                          child: DroneStatus(
                            constrains: constrains,
                          ),
                        ),
                      ),
                    ],
                  );
                },
              ),
            ),
          );
        });
  }
}
