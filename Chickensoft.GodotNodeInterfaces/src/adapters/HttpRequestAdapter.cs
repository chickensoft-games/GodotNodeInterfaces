namespace Chickensoft.GodotNodeInterfaces;

using Godot;
using System;
/// <summary>
/// <para>A node with the ability to send HTTP requests. Uses <see cref="HttpClient" /> internally.</para>
/// <para>Can be used to make HTTP requests, i.e. download or upload files or web content via HTTP.</para>
/// <para><b>Warning:</b> See the notes and warnings on <see cref="HttpClient" /> for limitations, especially regarding TLS security.</para>
/// <para><b>Note:</b> When exporting to Android, make sure to enable the <c>INTERNET</c> permission in the Android export preset before exporting the project or using one-click deploy. Otherwise, network communication of any kind will be blocked by Android.</para>
/// <para><b>Example of contacting a REST API and printing one of its returned fields:</b></para>
/// <para><code>
/// public override void _Ready()
/// {
/// // Create an HTTP request node and connect its completion signal.
/// var httpRequest = new HTTPRequest();
/// AddChild(httpRequest);
/// httpRequest.RequestCompleted += HttpRequestCompleted;
/// // Perform a GET request. The URL below returns JSON as of writing.
/// Error error = httpRequest.Request("https://httpbin.org/get");
/// if (error != Error.Ok)
/// {
/// GD.PushError("An error occurred in the HTTP request.");
/// }
/// // Perform a POST request. The URL below returns JSON as of writing.
/// // Note: Don't make simultaneous requests using a single HTTPRequest node.
/// // The snippet below is provided for reference only.
/// string body = new Json().Stringify(new Godot.Collections.Dictionary
/// {
/// { "name", "Godette" }
/// });
/// error = httpRequest.Request("https://httpbin.org/post", null, HTTPClient.Method.Post, body);
/// if (error != Error.Ok)
/// {
/// GD.PushError("An error occurred in the HTTP request.");
/// }
/// }
/// // Called when the HTTP request is completed.
/// private void HttpRequestCompleted(long result, long responseCode, string[] headers, byte[] body)
/// {
/// var json = new Json();
/// json.Parse(body.GetStringFromUtf8());
/// var response = json.GetData().AsGodotDictionary();
/// // Will print the user agent string used by the HTTPRequest node (as recognized by httpbin.org).
/// GD.Print((response["headers"].AsGodotDictionary())["User-Agent"]);
/// }
/// </code></para>
/// <para><b>Example of loading and displaying an image using HTTPRequest:</b></para>
/// <para><code>
/// public override void _Ready()
/// {
/// // Create an HTTP request node and connect its completion signal.
/// var httpRequest = new HTTPRequest();
/// AddChild(httpRequest);
/// httpRequest.RequestCompleted += HttpRequestCompleted;
/// // Perform the HTTP request. The URL below returns a PNG image as of writing.
/// Error error = httpRequest.Request("https://via.placeholder.com/512");
/// if (error != Error.Ok)
/// {
/// GD.PushError("An error occurred in the HTTP request.");
/// }
/// }
/// // Called when the HTTP request is completed.
/// private void HttpRequestCompleted(long result, long responseCode, string[] headers, byte[] body)
/// {
/// if (result != (long)HTTPRequest.Result.Success)
/// {
/// GD.PushError("Image couldn't be downloaded. Try a different image.");
/// }
/// var image = new Image();
/// Error error = image.LoadPngFromBuffer(body);
/// if (error != Error.Ok)
/// {
/// GD.PushError("Couldn't load the image.");
/// }
/// var texture = ImageTexture.CreateFromImage(image);
/// // Display the image in a TextureRect node.
/// var textureRect = new TextureRect();
/// AddChild(textureRect);
/// textureRect.Texture = texture;
/// }
/// </code></para>
/// <para><b>Gzipped response bodies</b>: HTTPRequest will automatically handle decompression of response bodies. A <c>Accept-Encoding</c> header will be automatically added to each of your requests, unless one is already specified. Any response with a <c>Content-Encoding: gzip</c> header will automatically be decompressed and delivered to you as uncompressed bytes.</para>
/// </summary>
public class HttpRequestAdapter : NodeAdapter, IHttpRequest {
  private readonly HttpRequest _node;

  public HttpRequestAdapter(HttpRequest node) : base(node) { _node = node; }

    /// <summary>
    /// <para>If <c>true</c>, this header will be added to each request: <c>Accept-Encoding: gzip, deflate</c> telling servers that it's okay to compress response bodies.</para>
    /// <para>Any Response body declaring a <c>Content-Encoding</c> of either <c>gzip</c> or <c>deflate</c> will then be automatically decompressed, and the uncompressed bytes will be delivered via <see cref="HttpRequest.RequestCompleted" />.</para>
    /// <para>If the user has specified their own <c>Accept-Encoding</c> header, then no header will be added regardless of <see cref="HttpRequest.AcceptGZip" />.</para>
    /// <para>If <c>false</c> no header will be added, and no decompression will be performed on response bodies. The raw bytes of the response body will be returned via <see cref="HttpRequest.RequestCompleted" />.</para>
    /// </summary>
    public bool AcceptGZip { get => _node.AcceptGZip; set => _node.AcceptGZip = value; }
    /// <summary>
    /// <para>Maximum allowed size for response bodies. If the response body is compressed, this will be used as the maximum allowed size for the decompressed body.</para>
    /// </summary>
    public int BodySizeLimit { get => _node.BodySizeLimit; set => _node.BodySizeLimit = value; }
    /// <summary>
    /// <para>Cancels the current request.</para>
    /// </summary>
    public void CancelRequest() => _node.CancelRequest();
    /// <summary>
    /// <para>The size of the buffer used and maximum bytes to read per iteration. See <see cref="HttpClient.ReadChunkSize" />.</para>
    /// <para>Set this to a lower value (e.g. 4096 for 4 KiB) when downloading small files to decrease memory usage at the cost of download speeds.</para>
    /// </summary>
    public int DownloadChunkSize { get => _node.DownloadChunkSize; set => _node.DownloadChunkSize = value; }
    /// <summary>
    /// <para>The file to download into. Will output any received file into it.</para>
    /// </summary>
    public string DownloadFile { get => _node.DownloadFile; set => _node.DownloadFile = value; }
    /// <summary>
    /// <para>Returns the response body length.</para>
    /// <para><b>Note:</b> Some Web servers may not send a body length. In this case, the value returned will be <c>-1</c>. If using chunked transfer encoding, the body length will also be <c>-1</c>.</para>
    /// </summary>
    public int GetBodySize() => _node.GetBodySize();
    /// <summary>
    /// <para>Returns the number of bytes this HTTPRequest downloaded.</para>
    /// </summary>
    public int GetDownloadedBytes() => _node.GetDownloadedBytes();
    /// <summary>
    /// <para>Returns the current status of the underlying <see cref="HttpClient" />. See <see cref="HttpClient.Status" />.</para>
    /// </summary>
    public HttpClient.Status GetHttpClientStatus() => _node.GetHttpClientStatus();
    /// <summary>
    /// <para>Maximum number of allowed redirects.</para>
    /// </summary>
    public int MaxRedirects { get => _node.MaxRedirects; set => _node.MaxRedirects = value; }
    /// <summary>
    /// <para>Creates request on the underlying <see cref="HttpClient" />. If there is no configuration errors, it tries to connect using <see cref="HttpClient.ConnectToHost(System.String,System.Int32,Godot.TlsOptions)" /> and passes parameters onto <see cref="HttpClient.Request(Godot.HttpClient.Method,System.String,System.String[],System.String)" />.</para>
    /// <para>Returns <see cref="Error.Ok" /> if request is successfully created. (Does not imply that the server has responded), <see cref="Error.Unconfigured" /> if not in the tree, <see cref="Error.Busy" /> if still processing previous request, <see cref="Error.InvalidParameter" /> if given string is not a valid URL format, or <see cref="Error.CantConnect" /> if not using thread and the <see cref="HttpClient" /> cannot connect to host.</para>
    /// <para><b>Note:</b> When <paramref name="method" /> is <see cref="HttpClient.Method.Get" />, the payload sent via <paramref name="requestData" /> might be ignored by the server or even cause the server to reject the request (check <a href="https://datatracker.ietf.org/doc/html/rfc7231#section-4.3.1">RFC 7231 section 4.3.1</a> for more details). As a workaround, you can send data as a query string in the URL (see <c>String.uri_encode</c> for an example).</para>
    /// <para><b>Note:</b> It's recommended to use transport encryption (TLS) and to avoid sending sensitive information (such as login credentials) in HTTP GET URL parameters. Consider using HTTP POST requests or HTTP headers for such information instead.</para>
    /// </summary>
    /// <param name="customHeaders">If the parameter is null, then the default value is <c>Array.Empty&lt;string&gt;()</c>.</param>
    public Error Request(string url, string[] customHeaders, HttpClient.Method @method, string requestData) => _node.Request(url, customHeaders, @method, requestData);
    /// <summary>
    /// <para>Creates request on the underlying <see cref="HttpClient" /> using a raw array of bytes for the request body. If there is no configuration errors, it tries to connect using <see cref="HttpClient.ConnectToHost(System.String,System.Int32,Godot.TlsOptions)" /> and passes parameters onto <see cref="HttpClient.Request(Godot.HttpClient.Method,System.String,System.String[],System.String)" />.</para>
    /// <para>Returns <see cref="Error.Ok" /> if request is successfully created. (Does not imply that the server has responded), <see cref="Error.Unconfigured" /> if not in the tree, <see cref="Error.Busy" /> if still processing previous request, <see cref="Error.InvalidParameter" /> if given string is not a valid URL format, or <see cref="Error.CantConnect" /> if not using thread and the <see cref="HttpClient" /> cannot connect to host.</para>
    /// </summary>
    /// <param name="customHeaders">If the parameter is null, then the default value is <c>Array.Empty&lt;string&gt;()</c>.</param>
    /// <param name="requestDataRaw">If the parameter is null, then the default value is <c>Array.Empty&lt;byte&gt;()</c>.</param>
    public Error RequestRaw(string url, string[] customHeaders, HttpClient.Method @method, byte[] requestDataRaw) => _node.RequestRaw(url, customHeaders, @method, requestDataRaw);
    /// <summary>
    /// <para>Sets the proxy server for HTTP requests.</para>
    /// <para>The proxy server is unset if <paramref name="host" /> is empty or <paramref name="port" /> is -1.</para>
    /// </summary>
    public void SetHttpProxy(string host, int port) => _node.SetHttpProxy(host, port);
    /// <summary>
    /// <para>Sets the proxy server for HTTPS requests.</para>
    /// <para>The proxy server is unset if <paramref name="host" /> is empty or <paramref name="port" /> is -1.</para>
    /// </summary>
    public void SetHttpsProxy(string host, int port) => _node.SetHttpsProxy(host, port);
    /// <summary>
    /// <para>Sets the <see cref="TlsOptions" /> to be used when connecting to an HTTPS server. See <see cref="TlsOptions.Client(Godot.X509Certificate,System.String)" />.</para>
    /// </summary>
    public void SetTlsOptions(TlsOptions clientOptions) => _node.SetTlsOptions(clientOptions);
    /// <summary>
    /// <para>The duration to wait in seconds before a request times out. If <see cref="HttpRequest.Timeout" /> is set to <c>0.0</c> then the request will never time out. For simple requests, such as communication with a REST API, it is recommended that <see cref="HttpRequest.Timeout" /> is set to a value suitable for the server response time (e.g. between <c>1.0</c> and <c>10.0</c>). This will help prevent unwanted timeouts caused by variation in server response times while still allowing the application to detect when a request has timed out. For larger requests such as file downloads it is suggested the <see cref="HttpRequest.Timeout" /> be set to <c>0.0</c>, disabling the timeout functionality. This will help to prevent large transfers from failing due to exceeding the timeout value.</para>
    /// </summary>
    public double Timeout { get => _node.Timeout; set => _node.Timeout = value; }
    /// <summary>
    /// <para>If <c>true</c>, multithreading is used to improve performance.</para>
    /// </summary>
    public bool UseThreads { get => _node.UseThreads; set => _node.UseThreads = value; }

}