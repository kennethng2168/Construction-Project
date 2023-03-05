class Location {
  String title;

  String age;

  String categorires;

  String image;

  String logo;

  double rating;

  String technology;

  DateTime date;

  Location(
      {required this.title,
      required this.image,
      required this.logo,
      required this.age,
      required this.rating,
      required this.date,
      required this.categorires,
      required this.technology});
}

final List<Location> movies = [
  Location(
    title: 'Construction Site',
    image: 'assets/images/construction.jpeg',
    logo: 'assets/images/logos/hilti_logo.png',
    age: 'PG-13',
    rating: 8.5,
    date: DateTime(2023),
    categorires: '',
    technology: ' Digital Twin, Drones, AI, NLP Chatbot, VR',
  ),
  Location(
    title: 'Warehouse',
    image: 'assets/images/warehouse.jpg',
    logo: 'assets/images/logos/hilti_logo.png',
    age: '18+',
    rating: 8.7,
    date: DateTime(2022),
    categorires: '',
    technology: ' Digital Twin, Drones, AI, NLP Chatbot, VR',
  ),
  Location(
    title: 'Twin Tower',
    image: 'assets/images/twin_tower.jpeg',
    logo: 'assets/images/logos/hilti_logo.png',
    age: 'R',
    rating: 8,
    date: DateTime(1993),
    categorires: '',
    technology: ' Digital Twin, Drones, AI, NLP Chatbot, VR',
  ),
  Location(
    title: 'Merdeka 118',
    image: 'assets/images/merdeka118.jpeg',
    logo: 'assets/images/logos/hilti_logo.png',
    age: 'PG-13',
    rating: 8.5,
    date: DateTime(2017),
    categorires: '',
    technology: ' Digital Twin, Drones, AI, NLP Chatbot, VR',
  ),
  // Movie(
  //     title: 'Once upon a time in Hollywood',
  //     image:
  //         'https://posterposse.com/wp-content/uploads/2019/07/Once-upon-a-time-in-hollywood-Poster-Posse-Hughes.png',
  //     logo: 'assets/images/logos/hollywood.png',
  //     age: 'R',
  //     rating: 7.7,
  //     date: DateTime(2019),
  //     categorires: 'Drama, Comedy-drama',
  //     technology: 'DataSat, Dolby Digital '),
];
