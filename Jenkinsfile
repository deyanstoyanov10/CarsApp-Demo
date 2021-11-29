pipeline {
    agent any
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