import os

try:
    import argparse
except:
    os.system("pip install argparse")

try:
    import requests
except:
    os.system("pip install requests")


def RemoveBG(initialpath, savepath, api_key):
    response = requests.post(
        'https://api.remove.bg/v1.0/removebg',
        files={'image_file': open(initialpath, 'rb')},
        data={'size': 'auto'},
        headers={'X-Api-Key': api_key},
    )
    if response.status_code == requests.codes.ok:
        with open(savepath, 'wb') as out:
            out.write(response.content)
    else:
        print("Error:", response.status_code, response.text)

if __name__ == "__main__":
    parser = argparse.ArgumentParser(description="Remove the background of an image using remove.bg API.")
    parser.add_argument('initialpath', type=str, help='Path to the input image file')
    parser.add_argument('savepath', type=str, help='Path to save the output image file')
    parser.add_argument('api_key', type=str, help='Your remove.bg API key')
    
    args = parser.parse_args()
    
    RemoveBG(args.initialpath, args.savepath, args.api_key)