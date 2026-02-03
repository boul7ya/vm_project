pipeline {
    agent any

    stages {

        stage('MDB open') {
            steps {
                bat 'curl -X POST http://localhost:8080/mdb/open/COM1'
            }
        }

        stage('MDB start') {
            steps {
                bat 'curl -X POST http://localhost:8080/mdb/start'
            }
        }

        stage('MDB vend') {
            steps {
                bat 'curl -X POST http://localhost:8080/mdb/vend/5'
            }
        }

        stage('MDB close') {
            steps {
                bat 'curl -X POST http://localhost:8080/mdb/close'
            }
        }

        stage('MDB state') {
            steps {
                bat 'curl http://localhost:8080/mdb/state'
            }
        }
    }
}
