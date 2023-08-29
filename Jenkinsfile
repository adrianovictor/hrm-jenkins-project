pipeline {  
    agent any  
 
    environment {
        // Git 
        GIT_PROJECT = 'https://github.com/adrianovictor/hrm-jenkins-project.git'
        GIT_CREDENTIALS = '7401f445-354e-4515-9604-b4b8b21bdc0d'
        GIT_BRANCH = 'master'

        // SonarQube
        SONAR_CREDENTIALS = 'sqp_d2e783327e1e46f40a373e103f971c766434900b'
        SONAR_URL = 'http://sonarqube:9000'
    }

    // Sempre incluir esse step de options/timeout para não "prender" o agente do Jenkins infinitamente
    options {
        timeout(time: 30, unit: 'MINUTES')
    }
    
    stages {  
        stage('Checkout') {  
            steps {
                git credentialsId: env.GIT_CREDENTIALS, url: env.GIT_PROJECT, branch: env.GIT_BRANCH
            }  
        }

        stage('Restore Packages') {
            steps {
                sh 'dotnet restore ${WORKSPACE}/HRM.sln'
            }
        }
        
        stage('Build Application') {
            steps {
                sh 'dotnet build ${WORKSPACE}/HRM.sln'
            }
        }
        
       stage('Coverage Tests') {
            steps {
                script {
                    sh 'dotnet restore ${WORKSPACE}/HRM.Tests/HRM.Tests.csproj'
                    sh 'dotnet test ${WORKSPACE}/HRM.Tests/HRM.Tests.csproj'
                }
            }
        }

        stage('Sonarqube Scan') {
            steps {
                script {
                        sh '''
                            export PATH="$PATH:/root/.dotnet/tools"
                            apt-get update && apt install default-jre -y 
                            /root/.dotnet/tools/dotnet-sonarscanner begin /k:"Projeto-HRM" /d:sonar.host.url="${SONAR_URL}"  /d:sonar.login="${SONAR_CREDENTIALS}"
                            dotnet build ${WORKSPACE}/HRM.Api/HRM.Api.csproj
                            /root/.dotnet/tools/dotnet-sonarscanner end /d:sonar.login="${SONAR_CREDENTIALS}"
                        '''                    
                }
            }
        }   

    }
}