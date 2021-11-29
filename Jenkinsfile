pipeline {
    agent any
    stages {
        stage ('Clean workspace') {
            steps {
                cleanWs()
            }
        }
        stage('Verify Branch') {
            steps {
                echo "$Branch"
            }
        }
    }
}