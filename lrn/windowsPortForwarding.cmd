netsh interface portproxy add v4tov4 listenport=31732 listenaddress=10.1.1.1 connectport=443 connectaddress=195.1.1.1

netsh interface portproxy show all

::netsh interface portproxy delete v4tov4 listenport=31732 listenaddress=10.1.1.1