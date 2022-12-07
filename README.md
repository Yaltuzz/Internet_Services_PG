# Run in development environment

To run application for development purposes on local environment run 

	    docker-compose -f docker-compose-dev.yaml
After the command, you can enter webpage http://localhost:1234 to see running application.

# Run in production environment
It's necessary to build and push to docker repository two docker images.
One dockerfile is in Dotnet_Service/Internet_Services_PG.  In this localization you can run

	    sudo docker build . -t yaltuzz/si_176446_dotnet
Next step is build second image in Generator_Service folder. In this folder run

	    sudo docker build . -t yaltuzz/si_176446_generator
Next you need to build third image which contains frontendd application. Folder name is vue-frontend and run this command into this folder.

    	sudo docker build . -t yaltuzz/si_176446_frontend
Later you need to push images to registry with commands:

	    docker push yaltuzz/si_176446_generator
	    docker push yaltuzz/si_176446_dotnet
	    docker push yaltuzz/si_176446_frontend
Cluster is running with docker-swarm so you can build composition with command:

	    sudo docker stack deploy -c docker-compose.yml PREFIX -- with-registry-auth
Now application is exposed on 8080 port.
