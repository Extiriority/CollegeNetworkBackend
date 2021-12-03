# College Network
<a href="(https://github.com/Extiriority/CollegeNetworkBackend"><img align="right" src="https://catalog.app.fhict.nl/images/menuGlobal.svg" width=27%></a>

CollegeNetwork is a fast and easy open-source social media network website and app,
this repository contains the API which is responsible for all functionality.
The front-end repository can be found at
[CollegeNetworkFrontend](https://github.com/Extiriority/CollegeNetworkFrontend).

## Goals

* Interconnect and build relationships with other students and professors in the same field.
* Create an environment where you can easily send messages to each other with similar interests, search for future related events, learn more in the same field and easily find new people.
* Accelerate your relationship with other students into a deeper connection outside of college.

## Development environment set-up

### Windows
On Windows, you will need to install Windows Subsystems for Linux (WSL) in order to run
the PostgreSQL Docker database that CollegeNetwork requires.

1. Enable WSL by going to the `Turn windows features on and off` settings tab
2. Go to the Microsoft Store and install Ubuntu or any distribution of your choosing

### Docker Database setup

1. `CD` into Docker folder
2. Build and start PostgreSQL in port 5432 by running:
```sh
docker build -t collegenetworkpostgres . && docker run -p 5432:5432 --name CollegeNetworkPostgres collegenetworkpostgres 
```
3. Configure the Datasource to PostgreSQL and input the credentials that is located in the Dockerfile

### Environment setup

1. Clone the [CollegeNetworkFrontend](https://github.com/Extiriority/CollegeNetworkFrontend) repository and
follow the setup instructions in the README
2. Clone this repository
3. Run CollegeNetworkFrontend and CollegeNetworkBackend at the same time, the frontend can then be found at `localhost:3000`
and the API will run at `localhost:8000`
