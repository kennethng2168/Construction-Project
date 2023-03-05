import requests


def weather(city):
    api_key = "edbbd1d7b50f468668e1e376376f730d"
    url = "http://api.openweathermap.org/data/2.5/weather?"

    final_url = url + "appid=" + api_key + "&q=" + city + "&units=metric"
    weather = requests.get(final_url).json()
    return weather

test = weather("Balakong")
print(test)


