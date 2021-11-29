pipeline {
    agent any
    stages {
        stage ('Clean workspace') {
            steps {
                cleanWs()
            }
        }
        stage('Git Clone') {
            steps {
                git branch: "$Branch",
                url: 'https://github.com/deyanstoyanov10/CarsApp-Demo.git'
            }
        }
        stage('Restore packages') {
            steps {
                powershell(
                    script: """ 
                    cd CarsApp
                    dotnet restore
                    cd ..
                    """)
            }
        }
    }
}