pipeline {
    agent any

    stages {

        stage('Start MDB simulator (Docker)') {
            steps {
                bat '''
                docker rm -f mdb || exit 0
                docker run -d -p 8080:8080 --name mdb mdb-api
                ping 127.0.0.1 -n 6 > nul
                '''
            }
        }

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

    post {
        always {
            bat 'docker rm -f mdb || exit 0'
        }
    }
}
