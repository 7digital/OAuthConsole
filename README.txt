A  tool to generate and make  7digital API requests 

The OAuth signature generation code, is derived from Google’s OAuth libraries, and has been modified to support OAuth POST requests.
Feel free to use this code in your own implementation.
This code is provided as is, and there is no official support from 7digital.
Using the OAuth Test Console
The OAuth test console, can be used to generate requests, and then send the requests.
To generate a OAuth signed request;

1. Enter the end point in the URI field
2. Provide your consumer key and consumer secret.
3. Leave the nonce and timestamp fields are optional. If these aren’t provided they will be generated for you.
4. Click generate signature.
5. If the request is a HTTP GET, you can copy the generated URI and use it in a web browser, or a command line tool such as curl or wget.
6. Click Make request to send a request.
7. The response from the remote server will be displayed in the Response text field.
8. Check the Console.Writeline tab for error messages. You can use the output of this tab to report issues to us.