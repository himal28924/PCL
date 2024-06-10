from flask import Flask

app = Flask(__name__)

@app.route("/")
def home():
    return f"<html> <body> <h1 style = 'color:blue'> GTG caffe </h1> </body> </html>"

if __name__ == "__main__":
    app.run(host='0.0.0.0')