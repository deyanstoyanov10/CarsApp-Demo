pipeline {
    agent any
    
    environment {
        DOTNET_SYSTEM_GLOBALIZATION_INVARIANT = 'true'
        PROJECT = "CarsApp"
    }
    stages {
        stage('Clean workspace') {
            steps {
                cleanWs()
            }
        }
        stage('Git Clone') {
            steps {
                git branch: "$BRANCH_NAME",
                url: 'https://github.com/deyanstoyanov10/CarsApp-Demo.git'
            }
        }
        stage('Restore Packages') {
            steps {
                dotnetRestore project: PROJECT + '.sln', sdk: '.net', workDirectory: env.WORKSPACE + '/' + PROJECT
            }
        }
    }
}