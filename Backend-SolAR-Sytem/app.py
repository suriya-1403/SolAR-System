from flask import Flask, jsonify
import tweepy
import webbrowser
import pandas as pd

app = Flask(__name__)


@app.route('/')
def index():
    ConsumerKey = "ZZwoqXXXXXXXXXXXXXXXXXXXX"
    ConsumerSecretKey = "Ilb6u3qOdtXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX"
    callback_uri = 'oob'
    auth = tweepy.OAuthHandler(ConsumerKey, ConsumerSecretKey, callback_uri)
    redirect_url = auth.get_authorization_url()
    webbrowser.open(redirect_url)
    user_pint_input = input("Whats the Pin value? ")
    # print(user_pint_input)
    auth.get_access_token(user_pint_input)
    api = tweepy.API(auth)
    Column = set()
    TweetsData = []
    AllowedTypes = [str, int]
    other_user = "nasa"
    Tweets = []
    for i, status in enumerate(tweepy.Cursor(api.user_timeline, screen_name=other_user).items(5)):
        print(i, status.text)
        Tweets.append(status.text)
        status_dict = dict(vars(status))
        keys = status_dict.keys()
        single_tweet_data = {}
        for k in keys:
            try:
                v_type = type(status_dict[k])
            except:
                v_type = None
            if v_type is not None:
                if v_type in AllowedTypes:
                    single_tweet_data[k] = status_dict[k]
                    Column.add(k)
        TweetsData.append(single_tweet_data)
    header_cols = list(Column)
    df = pd.DataFrame(TweetsData, columns=header_cols)
    df.head()
    json = df.to_json()
    return jsonify(json)


if __name__ == '__main__':
    app.run()
