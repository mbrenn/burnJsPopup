pipeline {
    agent any

    stages {
        
        stage('Preparation')
        {
            steps
            {                    
                sh """ 
                    export DOTNET_ROOT=/usr/share/dotnet/
                    npm install
                    dotnet tool install Cake.Tool --version 5.0.0
                    dotnet tool restore 
                """
            }
        }

        stage ('Builds')
        {
            steps 
            {
                sh 'dotnet cake'
            }
        }
        

        stage ('Package')
        {
            steps 
            {
                sh 'dotnet cake --target="Package"'
            }
        }
    }
}