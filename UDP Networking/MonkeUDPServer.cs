internal class MonkeUDPServer
    {
        public static UdpClient Host(int serverport, Storage storage)
        {
            string publicIpAddress = IPQuery();
            if (IPAddress.TryParse(publicIpAddress, out IPAddress serverIpAddress))
            {
            }
            /* string hostName = Dns.GetHostName();
            IPAddress[] hostAddresses = Dns.GetHostAddresses(hostName);
            IPAddress serverIpAddress = Array.Find(hostAddresses, address => address.AddressFamily == AddressFamily.InterNetworkV6); */
            if (serverIpAddress == null)
            {
                MelonLogger.Msg("No suitable IPv6 address found. Exiting.");
                return null;
            }
            UdpClient server = new UdpClient(new IPEndPoint(serverIpAddress, serverport));
            IPEndPoint serverEndPoint = (IPEndPoint)server.Client.LocalEndPoint;
            MelonLogger.Msg($"UDP Peer-to-Peer Server started on {serverEndPoint.Address}:{serverEndPoint.Port}. Waiting for connections...");
            storage.active = true;
            storage.host = true;
            return server;
        }
        public static async void Client(int serverport, Storage storage)
        {
            storage.server = new UdpClient();
            storage.ServerIPAddress = new IPEndPoint(storage.ServerIP, serverport);
            MelonLogger.Msg("UDP Peer-to-Peer Client started.");
            storage.active = true;
            storage.host = false;
        }
        static string IPQuery()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    string responseJson = httpClient.GetStringAsync("https://api64.ipify.org?format=json").Result;

                    // Manually parse JSON to extract the IP address
                    int startIndex = responseJson.IndexOf("\"ip\":") + 6;
                    int endIndex = responseJson.IndexOf("\"", startIndex);

                    if (startIndex >= 6 && endIndex > startIndex)
                    {
                        return responseJson.Substring(startIndex, endIndex - startIndex);
                    }
                    else
                    {
                        Console.WriteLine("Invalid JSON format or unable to extract IP address.");
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error retrieving public IP address: {ex.Message}");
                    return null;
                }
            }
        }
    }