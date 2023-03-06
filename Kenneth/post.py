# importing the requests library
import json
from requests.auth import HTTPBasicAuth
import requests

# defining the api-endpoint
url = "https://hilti-4a670-default-rtdb.asia-southeast1.firebasedatabase.app/row5.json"

data = {
        'light':0
}

data = json.dumps(data, indent=4)

headers = {'Accept': 'application/json'}

# sending post request and saving response as response object
r = requests.put(url = url, headers=headers, data = data)

print(r.text)
