import subprocess

subprocess.run('docker run -p 8000:8000 rasa/duckling')
subprocess.run('rasa shell', shell = True)